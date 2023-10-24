using Services;
using UnityEngine;
using Zenject;

namespace Common
{
    public class DeathSound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        private SoundService _soundService;

        [Inject]
        private void Inject(SoundService soundService) => _soundService = soundService;

        public void PlayDeathSound() => _soundService.PlayDeathSound(audioSource);
    }
}