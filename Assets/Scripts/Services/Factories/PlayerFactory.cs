﻿using System.Threading.Tasks;
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
        private readonly PlayerModelAssetProvider _playerModelAssetProvider;
        private readonly PlayerReferenceHolder _playerReferenceHolder;

        private GameObject _model;

        private PlayerFactory(DiContainer container, PlayerAssetProvider playerAssetProvider, PlayerDataHolder playerDataHolder, SpawnPositionsProvider spawnPositionsProvider,PlayerModelAssetProvider playerModelAssetProvider, PlayerReferenceHolder playerReferenceHolder)
        {
            _container = container;
            _playerAssetProvider = playerAssetProvider;
            _playerDataHolder = playerDataHolder;
            _spawnPositionsProvider = spawnPositionsProvider;
            _playerModelAssetProvider = playerModelAssetProvider;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public async Task Create()
        {
            Task<Player> playerAsset = _playerAssetProvider.LoadPlayerAsset();
            await playerAsset;
            Object.Destroy(_model);
            var player = _container.InstantiatePrefabForComponent<Player>(playerAsset.Result, _spawnPositionsProvider.SpawnPositions[0].position, Quaternion.identity, null);
            _playerReferenceHolder.SetPlayer(player);
            player.GetComponent<NicknameUI>().SetNickname(_playerDataHolder.PlayerStatisticsModel.Name);
        }

        public async Task CreateModel()
        {
            Task<GameObject> playerAsset = _playerModelAssetProvider.LoadPlayerAsset();
            await playerAsset;
            _model = _container.InstantiatePrefab(playerAsset.Result, _spawnPositionsProvider.SpawnPositions[0].position, Quaternion.identity, null);
        }
    }
}