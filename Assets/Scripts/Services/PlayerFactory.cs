using Players;
using UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly Player _playerPrefab;
        private readonly Vector3 _spawnPosition;
        private readonly PlayerDataHolder _playerDataHolder;

        public PlayerFactory(IObjectResolver objectResolver, Player playerPrefab, Vector3 spawnPosition, PlayerDataHolder playerDataHolder )
        {
            _objectResolver = objectResolver;
            _playerPrefab = playerPrefab;
            _spawnPosition = spawnPosition;
            _playerDataHolder = playerDataHolder;
        }

        public void Create()
        {
            var player = _objectResolver.Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }
    }
}