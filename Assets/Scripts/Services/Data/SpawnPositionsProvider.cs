﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Data
{
    public class SpawnPositionsProvider : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        private Transform[] _spawnPositions;

        public Transform[] SpawnPositions => _spawnPositions;

        public void CreateSpawnPoints(int num, Vector3 point, float radius)
        {
            if (_spawnPositions != null)
            {
                for (int i = _spawnPositions.Length - 1; i >= 0; i--)
                {
                    Destroy(_spawnPositions[i].gameObject);  
                }
            }
            
            _spawnPositions = new Transform[num];
            
            for (int i = num - 1; i >= 0; i--)
            {
                float radians = 2 * Mathf.PI / num * i;

                float vertical = Mathf.Sin(radians);
                float horizontal = Mathf.Cos(radians);

                var spawnDir = new Vector3(horizontal, 0, vertical);

                Vector3 spawnPos = point + spawnDir * radius;

                var transform = new GameObject
                {
                    name = $"SpawnPosition {i}",
                    transform =
                    {
                        position = spawnPos,
                        parent = parent
                    }
                };

                transform.transform.LookAt(point);
                _spawnPositions[i] = transform.transform;
            }
        }
    }
}