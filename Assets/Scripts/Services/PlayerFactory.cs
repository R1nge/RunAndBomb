using Players;
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

        public PlayerFactory(IObjectResolver objectResolver, Player playerPrefab, Vector3 spawnPosition)
        {
            _objectResolver = objectResolver;
            _playerPrefab = playerPrefab;
            _spawnPosition = spawnPosition;
        }

        public void Spawn() => _objectResolver.Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity);
    }
}