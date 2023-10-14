using UnityEngine;

namespace Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Throw = Animator.StringToHash("Throw");
        
        public void PlayWalkAnimation(float speed) => animator.SetFloat(Speed, speed);

        public void PlayThrowBombAnimation() => animator.SetTrigger(Throw);
    }
}