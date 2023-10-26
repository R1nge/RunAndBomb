using System.Collections;
using Common;
using Services;
using Services.Data;
using UIs;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyDeathController
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyCounter _enemyCounter;
        private readonly RagdollController _ragdollController;
        private readonly ColliderController _colliderController;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly ConfigProvider _configProvider;
        private readonly NicknameUI _nicknameUI;
        private readonly DeathSound _deathSound;

        public EnemyDeathController(NavMeshAgent navMeshAgent, EnemyCounter enemyCounter, RagdollController ragdollController, ColliderController colliderController, CoroutineRunner coroutineRunner, ConfigProvider configProvider, NicknameUI nicknameUI, DeathSound deathSound)
        {
            _navMeshAgent = navMeshAgent;
            _enemyCounter = enemyCounter;
            _ragdollController = ragdollController;
            _colliderController = colliderController;
            _coroutineRunner = coroutineRunner;
            _configProvider = configProvider;
            _nicknameUI = nicknameUI;
            _deathSound = deathSound;
        }

        public void Die()
        {
            _nicknameUI.Hide();
            _colliderController.DisableCharacterColliders();
            _navMeshAgent.isStopped = true;
            _enemyCounter.Decrease();
            _ragdollController.EnableRagdoll();
            _deathSound.PlayDeathSound();
            _coroutineRunner.StartCoroutine(FallThroughFloor());
        }
        
        private IEnumerator FallThroughFloor()
        {
            yield return new WaitForSeconds(_configProvider.EnemyConfig.DisableColliderDelay);
            _colliderController.DisableRagdollColliders();
        }
    }
}