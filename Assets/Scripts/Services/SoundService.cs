using System;
using System.Collections.Generic;
using Services.Data.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using Random = UnityEngine.Random;

namespace Services
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource clickSource;
        [SerializeField] private AssetReferenceT<AudioClip> clickSound;
        [SerializeField] private List<AssetReferenceT<AudioClip>> deathSounds;
        [SerializeField] private List<AssetReferenceT<AudioClip>> explosionSounds;
        private Dictionary<SoundType, List<AsyncOperationHandle>> _handles;
        private ISettingsDataService _settingsDataService;
        private SettingsService _settingsService;

        [Inject]
        private void Inject(ISettingsDataService settingsDataService, SettingsService settingService)
        {
            _settingsDataService = settingsDataService;
            _settingsService = settingService;
        }

        private void Awake()
        {
            _handles = new Dictionary<SoundType, List<AsyncOperationHandle>>();
            _settingsDataService.OnModelLoaded += OnSettingsLoaded;
            _settingsService.OnSoundsStatusChanged += SoundsStatusChanged;
        }

        private void OnSettingsLoaded(Settings settings) => SoundsStatusChanged(settings.SoundEnabled);

        private void SoundsStatusChanged(bool isEnabled)
        {
            if (isEnabled)
            {
                LoadSounds();
            }
            else
            {
                UnloadSounds();
            }
        }

        private void LoadSounds()
        {
            _handles.Clear();

            var clickSounds = new List<AsyncOperationHandle>
            {
                clickSound.LoadAssetAsync()
            };

            _handles.Add(SoundType.Click, clickSounds);

            var deathSoundsHandles = new List<AsyncOperationHandle>();

            for (int i = 0; i < deathSounds.Count; i++)
            {
                deathSoundsHandles.Add(deathSounds[i].LoadAssetAsync());
            }

            _handles.Add(SoundType.Death, deathSoundsHandles);

            var explosionSoundsHandle = new List<AsyncOperationHandle>();

            for (int i = 0; i < explosionSounds.Count; i++)
            {
                explosionSoundsHandle.Add(explosionSounds[i].LoadAssetAsync());
            }

            _handles.Add(SoundType.Explosion, explosionSoundsHandle);
        }

        private void UnloadSounds()
        {
            if (_handles.Count == 0) return;

            for (int i = 0; i < _handles[SoundType.Click].Count; i++)
            {
                Addressables.Release(_handles[SoundType.Click][i].Result);
            }

            for (int i = 0; i < _handles[SoundType.Death].Count; i++)
            {
                Addressables.Release(_handles[SoundType.Death][i].Result);
            }

            for (int i = 0; i < _handles[SoundType.Explosion].Count; i++)
            {
                Addressables.Release(_handles[SoundType.Explosion][i].Result);
            }
        }

        public void PlayClickSound()
        {
            if (!SoundsEnabled()) return;

            if (_handles[SoundType.Click][0].IsValid() && clickSource.clip)
            {
                clickSource.Play();
                return;
            }

            clickSource.clip = _handles[SoundType.Click][0].Result as AudioClip;
            clickSource.Play();
        }

        public void PlayDeathSound(AudioSource source)
        {
            if (!SoundsEnabled()) return;

            int index = Random.Range(0, deathSounds.Count);

            if (_handles[SoundType.Death][index].IsValid() && source.clip)
            {
                source.Play();
                return;
            }

            source.clip = _handles[SoundType.Death][index].Result as AudioClip;
            source.Play();
        }

        public void PlayExplosionSound(AudioSource source)
        {
            if (!SoundsEnabled()) return;

            int index = Random.Range(0, explosionSounds.Count);

            if (_handles[SoundType.Explosion][index].IsValid() && source.clip)
            {
                source.Play();
                return;
            }

            source.clip = _handles[SoundType.Explosion][index].Result as AudioClip;
            source.Play();
        }

        private bool SoundsEnabled() => _settingsDataService.Model.SoundEnabled;

        private void OnDestroy()
        {
            _settingsDataService.OnModelLoaded -= OnSettingsLoaded;
            _settingsService.OnSoundsStatusChanged -= SoundsStatusChanged;
        }

        private enum SoundType
        {
            Click,
            Death,
            Explosion
        }
    }
}