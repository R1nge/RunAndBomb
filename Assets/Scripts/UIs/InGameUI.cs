using Data;
using Services;
using Services.Data;
using TMPro;
using UnityEngine;
using VContainer;

namespace UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemiesLeft;
        [SerializeField] private TextMeshProUGUI levelText;
        private EnemyCounter _enemyCounter;
        private PlayerDataHolder _playerDataHolder;

        [Inject]
        private void Inject(EnemyCounter enemyCounter, PlayerDataHolder playerDataHolder)
        {
            _enemyCounter = enemyCounter;
            _playerDataHolder = playerDataHolder;
        }

        private void Start()
        {
            _enemyCounter.OnEnemyCountChanged += UpdateEnemyCount;
            UpdateEnemyCount(_enemyCounter.EnemyCount);
            UpdateLevel(_playerDataHolder.PlayerStatisticsModel);
        }

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"Enemies left: {amount}";

        private void UpdateLevel(PlayerStatisticsModel data) => levelText.text = $"Level: {data.Level}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}