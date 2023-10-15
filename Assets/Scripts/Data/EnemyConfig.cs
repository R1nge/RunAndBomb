using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float walkRadius;
        [SerializeField] private float disableColliderDelay;
        //TODO: move spawn positions to a services
        [SerializeField] private Vector3[] spawnPositions;

        public float WalkRadius => walkRadius;
        public float DisableColliderDelay => disableColliderDelay;
        public Vector3[] SpawnPositions => spawnPositions;
    }
}