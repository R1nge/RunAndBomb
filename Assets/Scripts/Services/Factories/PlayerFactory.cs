using System.Threading.Tasks;
using Players;
using Services.Assets;
using Services.Data;
using UIs;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly PlayerAssetProvider _playerAssetProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly RestartService _restartService;

        private PlayerFactory(DiContainer container, PlayerAssetProvider playerAssetProvider, PlayerDataHolder playerDataHolder, SpawnPositionsProvider spawnPositionsProvider, RestartService restartService)
        {
            _container = container;
            _playerAssetProvider = playerAssetProvider;
            _playerDataHolder = playerDataHolder;
            _spawnPositionsProvider = spawnPositionsProvider;
            _restartService = restartService;
        }

        public async Task Create()
        {
            Task<Player> playerAsset = _playerAssetProvider.LoadPlayerAsset();
            await playerAsset;
            var player = _container.InstantiatePrefabForComponent<Player>(playerAsset.Result, _spawnPositionsProvider.SpawnPositions[0].position, Quaternion.identity, null);
            _restartService.SetPlayer(player);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }
    }
}