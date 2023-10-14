using UnityEngine;

namespace Common
{
    public class ColliderController : MonoBehaviour
    {
        [SerializeField] private Collider[] colliders;

        public void DisableAllColliders()
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }
}