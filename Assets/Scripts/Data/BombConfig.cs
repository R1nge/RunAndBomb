using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BombConfig", menuName = "Bomb Config")]
    public class BombConfig : ScriptableObject
    {
        [SerializeField] private float mass;
        [SerializeField] private float drag;
        [SerializeField] private Vector3 gravity;

        public float Mass => mass;
        public float Drag => drag;
        public Vector3 Gravity => gravity;
    }
}