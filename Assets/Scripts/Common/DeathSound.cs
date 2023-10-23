using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Common
{
    public class DeathSound : MonoBehaviour
    {
        [SerializeField] private AssetReferenceT<AudioClip>[] deathSounds;
        [SerializeField] private AudioSource audioSource;
        
        public async void PlayDeathSound()
        {
            int index = Random.Range(0, deathSounds.Length);
            AsyncOperationHandle<AudioClip> task = deathSounds[index].LoadAssetAsync();
            await task.Task;
            audioSource.clip = task.Result;
        }
    }
}