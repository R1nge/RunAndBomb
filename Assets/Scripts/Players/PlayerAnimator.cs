using UnityEngine;

namespace Players
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Throw = Animator.StringToHash("Throw");
        private static readonly int HasWon = Animator.StringToHash("HasWon");

        public void PlayWalkingAnimation(float speed) => animator.SetFloat(Speed, speed);

        public void PlayThrowBombAnimation() => animator.SetTrigger(Throw);
        
        public void PlayDanceAnimation()=> animator.SetBool(HasWon, true);
    }
}