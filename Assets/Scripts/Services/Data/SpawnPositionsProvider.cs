using UnityEngine;

namespace Services.Data
{
    public class SpawnPositionsProvider
    {
        private Vector3[] _spawnPositions;

        public Vector3[] SpawnPositions => _spawnPositions;

        public void CreateSpawnPoints(int num, Vector3 point, float radius)
        {
            _spawnPositions = new Vector3[num];
            
            for (int i = num - 1; i >= 0; i--)
            {
                float radians = 2 * Mathf.PI / num * i;

                float vertical = Mathf.Sin(radians);
                float horizontal = Mathf.Cos(radians);

                var spawnDir = new Vector3(horizontal, 0, vertical);

                Vector3 spawnPos = point + spawnDir * radius;
                
                _spawnPositions[i] = spawnPos;
            }
        }
    }
}