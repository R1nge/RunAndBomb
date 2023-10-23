using Data;
using Services.Data;
using Services.Factories;
using Unity.AI.Navigation;
using UnityEngine;

namespace Services.Maps
{
    public class MapGenerator
    {
        private readonly ConfigProvider _configProvider;
        private readonly PlatformFactory _factory;
        private readonly PlatformDataHolder _platformDataHolder;

        private MapGenerator(ConfigProvider configProvider, PlatformFactory platformFactory, PlatformDataHolder platformDataHolder)
        {
            _configProvider = configProvider;
            _factory = platformFactory;
            _platformDataHolder = platformDataHolder;
        }

        public void Generate()
        {
            MapConfig config = _configProvider.MapConfig;

            Platform basePlatform = _factory.CreateBase();
            _platformDataHolder.Add(basePlatform);

            Vector3 position = Vector3.zero;

            Platform[] platforms = config.Platforms;

            for (int i = 0; i < platforms.Length; i++)
            {
                Vector3 offset = config.CircleOffsets[i];
                int spawnAmount = config.PlatformsCount[i];
                float angleStep = 360f / spawnAmount;

                for (int j = 0; j < spawnAmount; j++)
                {
                    Platform platform = _factory.CreateCircle(i);
                    _platformDataHolder.Add(platform);
                    platform.transform.position = offset;
                    platform.transform.RotateAround(position, Vector3.up, angleStep * j);
                }
            }

            basePlatform.GetComponentInChildren<NavMeshSurface>().BuildNavMesh();
        }
    }
}