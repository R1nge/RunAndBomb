using UnityEngine;

namespace Players
{
    public class TrajectoryDrawer : MonoBehaviour
    {
        [Header("Line renderer veriables")]
        [SerializeField] private LineRenderer line;

        [SerializeField, Range(2, 30)] private int resolution;
        
        
    }
}