using VContainer;
using VContainer.Unity;

namespace Services
{
    public class PlayerSpawner
    {
        private readonly IObjectResolver _objectResolver;
        private readonly Player.Player _playerPrefab;

        public PlayerSpawner(IObjectResolver objectResolver, Player.Player playerPrefab)
        {
            _objectResolver = objectResolver;
            _playerPrefab = playerPrefab;
        }

        public void Spawn()
        {
            _objectResolver.Instantiate(_playerPrefab);
        }
    }
}