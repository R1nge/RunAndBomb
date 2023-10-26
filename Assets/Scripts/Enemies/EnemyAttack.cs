using Bombs;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyAttack
    {
        private readonly BombController _bombController;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly NavMeshAgent _navMeshAgent;
        
        public EnemyAttack(BombController bombController, EnemyAnimator enemyAnimator, NavMeshAgent navMeshAgent)
        {
            _bombController = bombController;
            _enemyAnimator = enemyAnimator;
            _navMeshAgent = navMeshAgent;
        }

        public void Attack()
        {
            _bombController.SetMultiplier(_navMeshAgent.speed);
            
            if (_bombController.TryThrow())
            {
                _enemyAnimator.PlayThrowBombAnimation();
            }
        }
    }
}