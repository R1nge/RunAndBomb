using Data;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement
    {
        private readonly Transform _transform;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyAnimator _enemyAnimator;
        private Transform _target;
        private Vector3 _destination;
        private bool _inProgress;

        public EnemyMovement(Transform transform, NavMeshAgent navMeshAgent, EnemyConfig enemyConfig, EnemyAnimator enemyAnimator)
        {
            _transform = transform;
            _navMeshAgent = navMeshAgent;
            _enemyConfig = enemyConfig;
            _enemyAnimator = enemyAnimator;
        }

        public void SetTarget(Transform target) => _target = target;

        public void Patrol()
        {
            if (_inProgress)
            {
                if (Vector3.Distance(_transform.position, _destination) <= _navMeshAgent.stoppingDistance)
                {
                    _inProgress = false;
                }

                _enemyAnimator.PlayWalkAnimation(_navMeshAgent.speed);
            }
            else
            {
                Vector3 randomDirection = Random.insideUnitSphere * _enemyConfig.WalkRadius;
                randomDirection += _transform.position;
                NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _enemyConfig.WalkRadius, 1);
                _destination = hit.position;
                _navMeshAgent.destination = _destination;

                _inProgress = true;
            }
        }

        public void Chase()
        {
            _inProgress = false;
            _navMeshAgent.destination = _target.position;
            _enemyAnimator.PlayWalkAnimation(_navMeshAgent.speed);
        }

        public bool IsInAttackRange()
        {
            return Vector3.Distance(_transform.position, _target.position) <= _navMeshAgent.stoppingDistance;
        }
    }
}