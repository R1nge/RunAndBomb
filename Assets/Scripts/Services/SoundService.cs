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
        private Dictionary<SoundType, AsyncOperationHandle> _handles;

        private void Awake()
        {
            _handles = new Dictionary<SoundType, AsyncOperationHandle>
            {
                { SoundType.Click, clickSound.LoadAssetAsync() },
                { SoundType.Death, deathSounds[0].LoadAssetAsync() }
            };
        }

        public async void PlayClickSound()
        {
            if (_handles[SoundType.Click].IsValid() && audioSource.clip)
            {
                audioSource.Play();
                return;
            }
            
            audioSource.clip = _handles[SoundType.Click].Result as AudioClip;
            audioSource.Play();
        }

        public async void PlayDeathSound(AudioSource source)
        {
            if (_handles[SoundType.Death].IsValid() && source.clip)
            {
                source.Play();
                return;
            }
            
            source.clip = _handles[SoundType.Death].Result as AudioClip;
            source.Play();
        }

        private enum SoundType
        {
            Click,
            Death
        }
    }
}