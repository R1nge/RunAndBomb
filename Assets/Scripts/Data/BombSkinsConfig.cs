using Bombs;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BombSkins", menuName = "Configs/Bomb Skins")]
    public class BombSkinsConfig : ScriptableObject
    {
        [SerializeField] private Bomb[] bombs;

        public Bomb[] Bombs => bombs;
    }
}