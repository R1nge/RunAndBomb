using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GeneratorData", menuName = "GeneratorData")]
    public class GeneratorData : ScriptableObject
    {
        [SerializeField] private int sizeX, sizeY;
        [SerializeField] private GameObject platform;

        public int SizeX => sizeX;
        public int SizeY => sizeY;
        public GameObject Platform => platform;
    }
}