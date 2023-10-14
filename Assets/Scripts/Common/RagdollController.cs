using UnityEngine;

namespace Common
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody[] rigidbodies;
        [SerializeField] private Collider[] colliders;

        private void Awake() => DisableRagdoll();

        private void DisableRagdoll()
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = true;
            }

            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }

            animator.enabled = true;
        }
        
        public void EnableRagdoll()
        {
            animator.enabled = false;
            
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = false;
            }

            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }
    }
}