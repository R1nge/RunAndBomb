using Enemies;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemySkins", menuName = "Configs/EnemySkins")]
    public class EnemySkinsConfig : ScriptableObject
    {
        [SerializeField] private Enemy[] skins;

        public Enemy[] Skins => skins;
    }
}