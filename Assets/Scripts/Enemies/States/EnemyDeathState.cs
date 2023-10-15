using System.Collections;
using Common;
using Data;
using Services;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.States
{
    public class EnemyDeathState : IEnemyState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyCounter _enemyCounter;
        private readonly RagdollController _ragdollController;
        private readonly ColliderController _colliderController;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EnemyConfig _enemyConfig;
        
        public EnemyDeathState(NavMeshAgent navMeshAgent, EnemyCounter enemyCounter, RagdollController ragdollController, ColliderController colliderController, CoroutineRunner coroutineRunner, EnemyConfig enemyConfig)
        {
            _navMeshAgent = navMeshAgent;
            _enemyCounter = enemyCounter;
            _ragdollController = ragdollController;
            _colliderController = colliderController;
            _coroutineRunner = coroutineRunner;
            _enemyConfig = enemyConfig;
        }

        public void Enter()
        {
            Debug.Log("Died");
            _navMeshAgent.isStopped = true;
            _enemyCounter.Decrease();
            _ragdollController.EnableRagdoll();
            _coroutineRunner.StartCoroutine(FallThroughFloor());
        }

        private IEnumerator FallThroughFloor()
        {
            yield return new WaitForSeconds(_enemyConfig.DisableColliderDelay);
            _colliderController.DisableAllColliders();
        }

        public void Update() { }

        public void Exit() { }
    }
}