using Bombs;
using Common;
using Data;
using Players;
using Services;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyConfig enemyConfig;
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

        [Inject]
        public void Inject(EnemyCounter enemyCounter, CoroutineRunner coroutineRunner)
        {
            _enemyCounter = enemyCounter;
            _coroutineRunner = coroutineRunner;
        }

        public void OnTriggerEntered(Collider other)
        {
            bool isChasing = _enemyStateMachine.CurrentEnemyStateType != EnemyStateType.Patrol;

            if (isChasing)
            {
                return;
            }

            if (other.TryGetComponent(out Player player))
            {
                _enemyMovement.SetTarget(player.transform);
                _enemyStateMachine.ChangeState(EnemyStateType.Chase);
                return;
            }

            if (other.TryGetComponent(out Enemy enemy))
            {
                _enemyMovement.SetTarget(enemy.transform);
                _enemyStateMachine.ChangeState(EnemyStateType.Chase);
            }
        }

        public void TakeDamage() => _enemyStateMachine.ChangeState(EnemyStateType.Death);

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _bombController = GetComponent<BombController>();
            _ragdollController = GetComponent<RagdollController>();
            _colliderController = GetComponent<ColliderController>();

            _enemyMovement = new EnemyMovement(transform, _navMeshAgent, enemyConfig, _enemyAnimator);
            _enemyAttack = new EnemyAttack(_bombController, _enemyAnimator);
        }

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine();
            
            _enemyStateMachine.AddState(EnemyStateType.Patrol, new EnemyPatrolState(_enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Chase, new EnemyChaseState(_enemyStateMachine, _enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Attack, new EnemyAttackState(_enemyStateMachine, _enemyAttack));
            _enemyStateMachine.AddState(EnemyStateType.Death, new EnemyDeathState(_navMeshAgent, _enemyCounter, _ragdollController, _colliderController, _coroutineRunner, enemyConfig));
            
            _enemyStateMachine.ChangeState(EnemyStateType.Patrol);
        }

        private void Update() => _enemyStateMachine.Update();
    }
}