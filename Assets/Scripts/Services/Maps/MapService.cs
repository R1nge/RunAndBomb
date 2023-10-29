using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Services.Data;
using Services.Factories;
using Unity.AI.Navigation;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Services.Maps
{
    public class MapService
    {
        public event Action OnTileDestroyed;
        private readonly ConfigProvider _configProvider;
        private readonly PlatformFactory _platformFactory;
        private readonly List<Platform> _platforms = new();
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private NavMeshSurface _navMeshSurface;

        private MapService(ConfigProvider configProvider, PlatformFactory platformFactory)
        {
            _configProvider = configProvider;
            _platformFactory = platformFactory;
        }

        public void Generate()
        {
            MapConfig config = _configProvider.MapConfig;

            Platform basePlatform = _platformFactory.CreateBase();
            Add(basePlatform);

            Vector3 position = Vector3.zero;

            Platform[] platforms = config.Platforms;

            for (int i = 0; i < platforms.Length; i++)
            {
                Vector3 offset = config.CircleOffsets[i];
                int spawnAmount = config.PlatformsCount[i];
                float angleStep = 360f / spawnAmount;

                for (int j = 0; j < spawnAmount; j++)
                {
                    Platform platform = _platformFactory.CreateCircle(i);
                    Add(platform);
                    platform.transform.position = offset;
                    platform.transform.RotateAround(position, Vector3.up, angleStep * j);
                }
            }

            _navMeshSurface = basePlatform.GetComponentInChildren<NavMeshSurface>();
            _navMeshSurface.BuildNavMesh();
        }
        
        public void DestroyMap()
        {
            for (int i = _platforms.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_platforms[i].gameObject);
            }

            Clear();
        }
        
        public IEnumerator DestroyPlatforms()
        {
            for (int i = _platforms.Count - 1; i > 0; i--)
            {
                var index = Random.Range(1, _platforms.Count);
                yield return new WaitForSeconds(_configProvider.MapConfig.DestroyInterval);
                _platforms[index].Drop();
                Remove(_platforms[index]);
                OnTileDestroyed?.Invoke();
                yield return new WaitForSeconds(.1f);
                _navMeshSurface.BuildNavMesh();
            }

            yield return new WaitForSeconds(.1f);
            _navMeshSurface.BuildNavMesh();
        }

        private void Add(Platform platform) => _platforms.Add(platform);

        private void Remove(Platform platform) => _platforms.Remove(platform);

        private void Clear() => _platforms.Clear();
    }
}