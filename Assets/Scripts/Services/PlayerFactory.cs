using Data;
using UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerDataHolder _playerDataHolder;

        public PlayerFactory(IObjectResolver objectResolver, PlayerConfig playerConfig, PlayerDataHolder playerDataHolder)
        {
            _objectResolver = objectResolver;
            _playerConfig = playerConfig;
            _playerDataHolder = playerDataHolder;
        }

        public void Create()
        {
            var player = _objectResolver.Instantiate(_playerConfig.PlayerPrefab, _playerConfig.SpawnPosition, Quaternion.identity);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }
    }
}