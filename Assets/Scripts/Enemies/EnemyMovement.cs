using Services.Data;
using Services.Maps;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement
    {
        private readonly Transform _transform;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly ConfigProvider _configProvider;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly MapDestructor _mapDestructor;
        private Transform _target;
        private Vector3 _destination;
        private bool _inProgress;
        private float _currentIntervalTimeLeft;

        public EnemyMovement(Transform transform, NavMeshAgent navMeshAgent, ConfigProvider configProvider, EnemyAnimator enemyAnimator, MapDestructor mapDestructor)
        {
            _transform = transform;
            _navMeshAgent = navMeshAgent;
            _configProvider = configProvider;
            _enemyAnimator = enemyAnimator;
            _mapDestructor = mapDestructor;
        }

        public void Init() => _mapDestructor.OnTileDestroyed += PickPosition;

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
                PickPosition();

                _inProgress = true;
            }
        }

        private void PickPosition()
        {
            if (!_inProgress) return;

            Vector3 randomDirection = Random.insideUnitSphere * _configProvider.EnemyConfig.WalkRadius;
            randomDirection += _transform.position;
            NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _configProvider.EnemyConfig.WalkRadius, 1);
            _destination = hit.position;
            _navMeshAgent.destination = _destination;
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

        public void Destroy() => _mapDestructor.OnTileDestroyed -= PickPosition;
    }
}