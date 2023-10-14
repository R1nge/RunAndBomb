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
        private Transform _target;
        private Vector3 _destination;
        private bool _inProgress;

        public EnemyMovement(Transform transform, NavMeshAgent navMeshAgent, EnemyConfig enemyConfig)
        {
            _transform = transform;
            _navMeshAgent = navMeshAgent;
            _enemyConfig = enemyConfig;
        }

        public void SetTarget(Transform target) => _target = target;

        public void Patrol()
        {
            Debug.Log($"[Patrolling Distance] {Vector3.Distance(_transform.position, _destination)}");

            if (_inProgress)
            {
                if (Vector3.Distance(_transform.position, _destination) <= _navMeshAgent.stoppingDistance)
                {
                    _inProgress = false;
                }
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

        public void Chase() => _navMeshAgent.destination = _target.position;
    }
}