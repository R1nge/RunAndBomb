using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float gravity;

        public float Speed => speed;
        public float Gravity => gravity;
    }
}