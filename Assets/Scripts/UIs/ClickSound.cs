using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIs
{
    public class ClickSound : MonoBehaviour
    {
        private Button _button;
        private SoundService _soundService;
        
        [Inject]
        private void Inject(SoundService soundService) => _soundService = soundService;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(_soundService.PlayClickSound);
        }

        private void OnDestroy() => _button.onClick.RemoveAllListeners();
    }
}