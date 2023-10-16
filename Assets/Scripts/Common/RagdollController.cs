using UnityEngine;

namespace Common
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody[] rigidbodies;

        private void Awake() => DisableRagdoll();

        private void DisableRagdoll()
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = true;
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
        }
    }
}