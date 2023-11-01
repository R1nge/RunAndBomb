using Bombs;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyAttack
    {
        private readonly BombController _bombController;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly NavMeshAgent _navMeshAgent;
        private Transform _target;

        public EnemyAttack(BombController bombController, EnemyAnimator enemyAnimator, NavMeshAgent navMeshAgent)
        {
            _bombController = bombController;
            _enemyAnimator = enemyAnimator;
            _navMeshAgent = navMeshAgent;
        }

        public void SetTarget(Transform target) => _target = target;

        public void Attack()
        {
            //TODO: calculate distance to the target

            _bombController.transform.LookAt(_target);


            float distance = Vector3.Distance(_bombController.transform.position, _target.transform.position);

            Debug.Log(distance);

            if (distance == 0)
            {
                distance = .1f;
            }

            distance *= Random.Range(7, 12);

            _bombController.SetMultiplier(_navMeshAgent.speed / distance);

            if (_bombController.TryThrow())
            {
                _enemyAnimator.PlayThrowBombAnimation();
            }
        }
    }
}