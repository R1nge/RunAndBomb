using Services;
using TMPro;
using UnityEngine;
using VContainer;

namespace UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemiesLeft;
        private EnemyCounter _enemyCounter;

        [Inject]
        private void Inject(EnemyCounter enemyCounter) => _enemyCounter = enemyCounter;
        
        private void Start()
        {
            _enemyCounter.OnEnemyCountChanged += UpdateEnemyCount;
            UpdateEnemyCount(_enemyCounter.EnemyCount);
        }

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"Enemies left: {amount}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}