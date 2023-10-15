using UnityEngine;

namespace Common
{
    public class ColliderController : MonoBehaviour
    {
        [SerializeField] private Collider[] ragdollColliders;
        [SerializeField] private Collider[] characterColliders;

        public void DisableRagdollColliders()
        {
            for (int i = 0; i < ragdollColliders.Length; i++)
            {
                ragdollColliders[i].enabled = false;
            }
        }

        public void DisableCharacterColliders()
        {
            for (int i = 0; i < characterColliders.Length; i++)
            {
                characterColliders[i].enabled = false;
            }
        }
    }
}