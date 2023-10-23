using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AssetReferenceT<AudioClip> clickSound;

        private AsyncOperationHandle<AudioClip> _clickSoundHandle;

        public async void PlayClickSound()
        {
            if (_clickSoundHandle.IsValid() && audioSource.clip)
            {
                audioSource.Play();
                return;
            }
            
            _clickSoundHandle = clickSound.LoadAssetAsync();

            await _clickSoundHandle.Task;
            audioSource.clip = _clickSoundHandle.Result;
            audioSource.Play();
        }
    }
}