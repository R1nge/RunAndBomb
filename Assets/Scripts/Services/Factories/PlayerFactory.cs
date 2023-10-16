using Services.Data;
using UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;

        private PlayerFactory(IObjectResolver objectResolver, ConfigProvider configProvider, PlayerDataHolder playerDataHolder, SpawnPositionsProvider spawnPositionsProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
            _playerDataHolder = playerDataHolder;
            _spawnPositionsProvider = spawnPositionsProvider;
        }

        public void Create()
        {
            var playerConfig = _configProvider.PlayerConfig;
            var player = _objectResolver.Instantiate(playerConfig.PlayerPrefab, _spawnPositionsProvider.SpawnPositions[0].position, Quaternion.identity);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }
    }
}