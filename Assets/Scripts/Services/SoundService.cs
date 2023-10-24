using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AssetReferenceT<AudioClip> clickSound;
        [SerializeField] private List<AssetReferenceT<AudioClip>> deathSounds;
        private Dictionary<SoundType, List<AsyncOperationHandle>> _handles;

        private void Awake()
        {
            _handles = new Dictionary<SoundType, List<AsyncOperationHandle>>();
            
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
        }

        public void PlayClickSound()
        {
            if (_handles[SoundType.Click][0].IsValid() && audioSource.clip)
            {
                audioSource.Play();
                return;
            }

            audioSource.clip = _handles[SoundType.Click][0].Result as AudioClip;
            audioSource.Play();
        }

        public void PlayDeathSound(AudioSource source)
        {
            int index = Random.Range(0, deathSounds.Count);

            if (_handles[SoundType.Death][index].IsValid() && source.clip)
            {
                source.Play();
                return;
            }

            source.clip = _handles[SoundType.Death][index].Result as AudioClip;
            source.Play();
        }

        private enum SoundType
        {
            Click,
            Death
        }
    }
}