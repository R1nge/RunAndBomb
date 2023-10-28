using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Services.Data;
using Services.Factories;
using Unity.AI.Navigation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Maps
{
    public class MapService
    {
        public event Action OnTileDestroyed;
        private readonly ConfigProvider _configProvider;
        private readonly PlatformFactory _platformFactory;
        private readonly List<Platform> _platforms = new();
        private NavMeshSurface _navMeshSurface;

        private MapService(ConfigProvider configProvider, PlatformFactory platformFactory)
        {
            _configProvider = configProvider;
            _platformFactory = platformFactory;
        }
        
        public IReadOnlyList<Platform> Platforms => _platforms;

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

            basePlatform.GetComponentInChildren<NavMeshSurface>().BuildNavMesh();
        }
        
        public void DestroyMap()
        {
            for (int i = 0; i < Platforms.Count ; i++)
            {
                Object.Destroy(Platforms[i].gameObject);
            }

            Clear();
        }
        
        public IEnumerator DestroyPlatforms()
        {
            _navMeshSurface = Platforms[0].GetComponentInChildren<NavMeshSurface>();
            for (int i = Platforms.Count - 1; i > 0; i--)
            {
                yield return new WaitForSeconds(_configProvider.MapConfig.DestroyInterval);
                Platforms[i].Drop();
                yield return new WaitForSeconds(.1f);
                _navMeshSurface.BuildNavMesh();
                Remove(Platforms[i]);
                OnTileDestroyed?.Invoke();
            }

            yield return new WaitForSeconds(.1f);
            _navMeshSurface.BuildNavMesh();
        }

        private void Add(Platform platform) => _platforms.Add(platform);

        private void Remove(Platform platform) => _platforms.Remove(platform);

        private void Clear() => _platforms.Clear();
    }
}