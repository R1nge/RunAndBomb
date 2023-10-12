using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GeneratorConfig", menuName = "GeneratorConfig")]
    public class GeneratorConfig : ScriptableObject
    {
        [SerializeField] private int sizeX, sizeZ;
        [SerializeField] private float platformSizeX, platformSizeZ;
        [SerializeField] private GameObject platform;

        public int SizeX => sizeX;
        public int SizeZ => sizeZ;
        public float PlatformSizeX => platformSizeX;
        public float PlatformSizeZ => platformSizeZ;
        public GameObject Platform => platform;
    }
}