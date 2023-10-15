using UnityEngine;

namespace Services
{
    public class SpawnPositionsProvider : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;

        public Transform[] SpawnPositions => spawnPositions;
    }
}