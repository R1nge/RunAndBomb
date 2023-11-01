using Enemies;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemySkins", menuName = "Configs/EnemySkins")]
    public class EnemySkinsConfig : ScriptableObject
    {
        [SerializeField] private AssetReferenceGameObject[] skins;

        public AssetReferenceGameObject[] Skins => skins;
    }
}