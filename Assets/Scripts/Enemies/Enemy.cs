using Bombs;
using Common;
using Enemies.States;
using Services;
using Services.Data;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private EnemyStateMachine _enemyStateMachine;
        private EnemyCounter _enemyCounter;
        private EnemyMovement _enemyMovement;
        private EnemyAttack _enemyAttack;
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;
        private BombController _bombController;
        private RagdollController _ragdollController;
        private ColliderController _colliderController;
        private CoroutineRunner _coroutineRunner;
        private EnemyDeathController _enemyDeathController;
        private ConfigProvider _configProvider;

        [Inject]
        private void Inject(EnemyCounter enemyCounter, CoroutineRunner coroutineRunner, ConfigProvider configProvider)
        {
            _enemyCounter = enemyCounter;
            _coroutineRunner = coroutineRunner;
            _configProvider = configProvider;
        }

        public void OnTriggerEntered(Collider other)
        {
            bool isChasing = _enemyStateMachine.CurrentEnemyStateType != EnemyStateType.Patrol;

            if (isChasing)
            {
                return;
            }

            _enemyMovement.SetTarget(other.transform);
            _enemyStateMachine.ChangeState(EnemyStateType.Chase);
        }

        public void TakeDamage() => _enemyStateMachine.ChangeState(EnemyStateType.Death);

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _bombController = GetComponent<BombController>();
            _ragdollController = GetComponent<RagdollController>();
            _colliderController = GetComponent<ColliderController>();
        }

        private void Start()
        {
            _enemyMovement = new EnemyMovement(transform, _navMeshAgent, _configProvider, _enemyAnimator);
            _enemyAttack = new EnemyAttack(_bombController, _enemyAnimator);
            _enemyDeathController = new EnemyDeathController(_navMeshAgent, _enemyCounter, _ragdollController, _colliderController, _coroutineRunner, _configProvider);

            _enemyStateMachine = new EnemyStateMachine();

            _enemyStateMachine.AddState(EnemyStateType.Patrol, new EnemyPatrolState(_enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Chase, new EnemyChaseState(_enemyStateMachine, _enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Attack, new EnemyAttackState(_enemyStateMachine, _enemyAttack));
            _enemyStateMachine.AddState(EnemyStateType.Death, new EnemyDeathState(_enemyDeathController));

            _enemyStateMachine.ChangeState(EnemyStateType.Patrol);
        }

        private void Update() => _enemyStateMachine.Update();
    }
}