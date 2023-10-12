using Services;
using TMPro;
using UnityEngine;
using VContainer;

namespace UIs
{
    public class EnemyCountUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemiesLeft;
        private EnemyCounter _enemyCounter;

        [Inject]
        private void Inject(EnemyCounter enemyCounter) => _enemyCounter = enemyCounter;

        //TODO: create a UI factory and show enemies UI (gameplay screen) when game has started
        private void Awake() => _enemyCounter.OnEnemyCountChanged += UpdateEnemyCount;

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"Enemies left: {amount}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}