using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement
    {
        private const int WALK_RADIUS = 15;
        private readonly Transform _transform;
        private readonly NavMeshAgent _navMeshAgent;
        private Transform _target;

        public EnemyMovement(Transform transform, NavMeshAgent navMeshAgent)
        {
            _transform = transform;
            _navMeshAgent = navMeshAgent;
        }

        public void SetTarget(Transform target) => _target = target;

        public void Patrol()
        {
            Vector3 randomDirection = Random.insideUnitSphere * WALK_RADIUS;
            randomDirection += _transform.position;
            NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, WALK_RADIUS, 1);
            Vector3 finalPosition = hit.position;
            _navMeshAgent.destination = finalPosition;
        }

        public void Chase() => _navMeshAgent.destination = _target.position;
    }
}