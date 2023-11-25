using System.Threading.Tasks;
using Players;
using Services.Assets;
using Services.Data;
using Services.Data.Player;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly PlayerAssetProvider _playerAssetProvider;
        private readonly IPlayerDataService _playerDataService;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly PlayerReferenceHolder _playerReferenceHolder;

        private GameObject _model;

        private PlayerFactory(DiContainer container, PlayerAssetProvider playerAssetProvider, IPlayerDataService playerDataService, SpawnPositionsProvider spawnPositionsProvider, PlayerReferenceHolder playerReferenceHolder)
        {
            _container = container;
            _playerAssetProvider = playerAssetProvider;
            _playerDataService = playerDataService;
            _spawnPositionsProvider = spawnPositionsProvider;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public async Task Create()
        {
            Task<Player> playerAsset = _playerAssetProvider.LoadPlayerAsset();
            await playerAsset;
            var player = _container.InstantiatePrefabForComponent<Player>(playerAsset.Result, _spawnPositionsProvider.SpawnPositions[0], Quaternion.identity, null);
            _playerReferenceHolder.SetPlayer(player);
            player.SetNickName(_playerDataService.Model.Name);
        }
    }
}