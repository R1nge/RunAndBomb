namespace Services
{
    public class PlayerAnimatorService
    {
        private readonly PlayerReferenceHolder _playerReferenceHolder;

        private PlayerAnimatorService(PlayerReferenceHolder playerReferenceHolder)
        {
            _playerReferenceHolder = playerReferenceHolder;
        }

        public void PlayDanceAnimation() => _playerReferenceHolder.Player.PlayerAnimator.PlayDanceAnimation();
    }
}