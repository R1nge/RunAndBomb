using UnityEngine;

namespace Common
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

        private void Awake()
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
        }
        
        private void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation((transform.position - camera.transform.position).normalized);
        }
    }
}