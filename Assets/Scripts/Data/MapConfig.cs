using Services.Maps;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Map Config")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private Platform basePlatform;
        [SerializeField] private Platform[] platforms;
        [SerializeField] private int[] platformsCount;
        [SerializeField] private Vector3[] circleOffsets;
        [SerializeField] private float destroyInterval;
        
        public Platform BasePlatform => basePlatform;
        public Platform[] Platforms => platforms;
        public ref int[] PlatformsCount => ref platformsCount;
        public ref Vector3[] CircleOffsets => ref circleOffsets;
        public float DestroyInterval => destroyInterval;
    }
}