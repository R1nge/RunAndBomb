using Bombs;

namespace Enemies
{
    public class EnemyAttack
    {
        private readonly BombController _bombController;
        private readonly EnemyAnimator _enemyAnimator;
        
        public EnemyAttack(BombController bombController, EnemyAnimator enemyAnimator)
        {
            _bombController = bombController;
            _enemyAnimator = enemyAnimator;
        }

        public void Attack()
        {
            if (_bombController.TryThrow())
            {
                _enemyAnimator.PlayThrowBombAnimation();
            }
        }
    }
}