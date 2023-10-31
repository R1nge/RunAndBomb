using Data;
using Services;
using Services.Data;
using Services.Data.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemiesLeft;
        [SerializeField] private TextMeshProUGUI levelText;
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

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"Enemies left: {amount}";

        private void UpdateLevel(PlayerStatisticsModel data) => levelText.text = $"Level: {data.Level}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}