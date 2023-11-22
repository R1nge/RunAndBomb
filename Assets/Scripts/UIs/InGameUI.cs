using System.Collections;
using Data;
using Services;
using Services.Data;
using Services.Data.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using Zenject;

namespace UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemiesLeft;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private KillPopupUI[] killPopups;
        [SerializeField] private LocalizedString enemies, level;
        private bool _killPopupIsActive;
        private EnemyCounter _enemyCounter;
        private IPlayerDataService _playerDataService;

        [Inject]
        private void Inject(EnemyCounter enemyCounter, IPlayerDataService playerDataService)
        {
            _enemyCounter = enemyCounter;
            _playerDataService = playerDataService;
        }

        private void Start()
        {
            _enemyCounter.OnEnemyCountChanged += UpdateEnemyCount;
            UpdateEnemyCount(_enemyCounter.EnemyCount);
            UpdateLevel(_playerDataService.Model);
        }

        public void ShowKillPopup()
        {
            if (_killPopupIsActive)
            {
                Debug.LogWarning("Kill popup is already active");
                return;
            }

            StartCoroutine(ShowKillPopupCoroutine());
        }

        private IEnumerator ShowKillPopupCoroutine()
        {
            _killPopupIsActive = true;
            int index = Random.Range(0, killPopups.Length);
            yield return killPopups[index].Show();
            killPopups[index].Hide();
            _killPopupIsActive = false;
        }

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"{enemies.GetLocalizedString() + amount}";

        private void UpdateLevel(PlayerStatisticsModel data) => levelText.text = $"{level.GetLocalizedString() + data.Level}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}