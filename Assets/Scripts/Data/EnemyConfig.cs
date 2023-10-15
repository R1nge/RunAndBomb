using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float walkRadius;
        [SerializeField] private float disableColliderDelay;

        public float WalkRadius => walkRadius;
        public float DisableColliderDelay => disableColliderDelay;
    }
}