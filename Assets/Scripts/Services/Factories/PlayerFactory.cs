using Players;
using Services.Data;
using UIs;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;

        private PlayerFactory(DiContainer container, ConfigProvider configProvider, PlayerDataHolder playerDataHolder, SpawnPositionsProvider spawnPositionsProvider)
        {
            _container = container;
            _configProvider = configProvider;
            _playerDataHolder = playerDataHolder;
            _spawnPositionsProvider = spawnPositionsProvider;
        }

        public void Create()
        {
            var playerConfig = _configProvider.PlayerConfig;
            var player = _container.InstantiatePrefabForComponent<Player>(playerConfig.PlayerPrefab, _spawnPositionsProvider.SpawnPositions[0].position, Quaternion.identity, null);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }
    }
}