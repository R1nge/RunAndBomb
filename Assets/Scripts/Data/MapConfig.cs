﻿using Services.Maps;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Configs/Map Config")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private Platform basePlatform;
        [SerializeField] private Platform[] platforms;
        [SerializeField] private int[] platformsCount;
        [SerializeField] private Vector3[] circleOffsets;
        [SerializeField] private float destroyInterval;

        [SerializeField] private int spawnPositionsAmount;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float spawnPositionY = 2.05f;
        
        public Platform BasePlatform => basePlatform;
        public Platform[] Platforms => platforms;
        public ref int[] PlatformsCount => ref platformsCount;
        public ref Vector3[] CircleOffsets => ref circleOffsets;
        public float DestroyInterval => destroyInterval;

        public int SpawnPositionsAmount => spawnPositionsAmount;
        public float SpawnRadius => spawnRadius;
        public float SpawnPositionY => spawnPositionY;
    }
}