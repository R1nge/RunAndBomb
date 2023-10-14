using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float disableColliderDelay;

        public float DisableColliderDelay => disableColliderDelay;
    }
}