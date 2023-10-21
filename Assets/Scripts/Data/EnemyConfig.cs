using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float walkRadius;
        [SerializeField] private float disableColliderDelay;
        [SerializeField] private float scanRadius;
        [SerializeField] private float delayBeforeNextScan;

        public float WalkRadius => walkRadius;
        public float DisableColliderDelay => disableColliderDelay;
        public float ScanRadius => scanRadius;
        public float DelayBeforeNextScan => delayBeforeNextScan;
    }
}