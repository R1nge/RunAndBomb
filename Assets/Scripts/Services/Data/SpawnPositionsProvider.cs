using UnityEngine;

namespace Services.Data
{
    public class SpawnPositionsProvider : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;

        public Transform[] SpawnPositions => spawnPositions;
    }
}