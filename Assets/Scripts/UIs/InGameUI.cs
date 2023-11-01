﻿using System.Collections;
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
        [SerializeField] private float killPopupDuration;
        [SerializeField] private KillPopupUI[] killPopups;
        private bool _killPopupIsActive;
        private YieldInstruction _wait;
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
            _wait = new WaitForSeconds(killPopupDuration);
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
            
            _killPopupIsActive = true;

            int index = Random.Range(0, killPopups.Length);
            killPopups[index].Show();
            StartCoroutine(HideKillPopup(index));
        }

        private IEnumerator HideKillPopup(int index)
        {
            yield return _wait;
            killPopups[index].Hide();
        }

        private void UpdateEnemyCount(int amount) => enemiesLeft.text = $"Enemies left: {amount}";

        private void UpdateLevel(PlayerStatisticsModel data) => levelText.text = $"Level: {data.Level}";

        private void OnDestroy() => _enemyCounter.OnEnemyCountChanged -= UpdateEnemyCount;
    }
}