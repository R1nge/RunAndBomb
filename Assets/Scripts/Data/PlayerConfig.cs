using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private AssetReferenceGameObject playerPrefab;
        [SerializeField] private float speed;
        [SerializeField] private float gravity;
        
        public AssetReferenceGameObject PlayerPrefab => playerPrefab;
        public float Speed => speed;
        public float Gravity => gravity;
    }
}