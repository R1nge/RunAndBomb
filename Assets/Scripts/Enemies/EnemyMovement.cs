using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement
    {
        private readonly NavMeshAgent _navMeshAgent;
        private Transform _target;

        public EnemyMovement(NavMeshAgent navMeshAgent) => _navMeshAgent = navMeshAgent;

        public void SetTarget(Transform target) => _target = target;

        public void Patrol()
        {
        }

        public void Chase()
        {
        }
    }
}