using Bombs;
using Common;
using Enemies.States;
using Services;
using Services.Data;
using Services.Maps;
using UIs;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private LayerMask ignore;
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
        private NicknameUI _nicknameUI;
        private DeathSound _deathSound;
        private MapService _mapService;
        private Collider[] _colliders;

        [Inject]
        private void Inject(EnemyCounter enemyCounter, CoroutineRunner coroutineRunner, ConfigProvider configProvider, MapService mapService)
        {
            _enemyCounter = enemyCounter;
            _coroutineRunner = coroutineRunner;
            _configProvider = configProvider;
            _mapService = mapService;
        }

        public void TakeDamage() => _enemyStateMachine.ChangeState(EnemyStateType.Death);

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _bombController = GetComponent<BombController>();
            _ragdollController = GetComponent<RagdollController>();
            _colliderController = GetComponent<ColliderController>();
            _nicknameUI = GetComponent<NicknameUI>();
            _deathSound = GetComponent<DeathSound>();

            _colliders = new Collider[6];
        }

        private void Start()
        {
            _enemyMovement = new EnemyMovement(transform, _navMeshAgent, _configProvider, _enemyAnimator, _mapService);
            _enemyMovement.Init();
            
            _bombController.SetMultiplier(_navMeshAgent.speed);
            
            _enemyAttack = new EnemyAttack(_bombController, _enemyAnimator, _navMeshAgent);
            _enemyDeathController = new EnemyDeathController(_navMeshAgent, _enemyCounter, _ragdollController, _colliderController, _coroutineRunner, _configProvider, _nicknameUI, _deathSound);

            _enemyStateMachine = new EnemyStateMachine();

            _enemyStateMachine.AddState(EnemyStateType.Patrol, new EnemyPatrolState(_enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Chase, new EnemyChaseState(_enemyStateMachine, _enemyMovement));
            _enemyStateMachine.AddState(EnemyStateType.Attack, new EnemyAttackState(_enemyStateMachine, _enemyAttack));
            _enemyStateMachine.AddState(EnemyStateType.Death, new EnemyDeathState(_enemyDeathController));

            _enemyStateMachine.ChangeState(EnemyStateType.Patrol);
            
            InvokeRepeating(nameof(DetectCharacter), _configProvider.EnemyConfig.DelayBeforeNextScan, _configProvider.EnemyConfig.DelayBeforeNextScan);
        }

        private void DetectCharacter()
        {
            bool isChasing = _enemyStateMachine.CurrentEnemyStateType != EnemyStateType.Patrol;

            if (isChasing)
            {
                return;
            }
            
            int hits = Physics.OverlapSphereNonAlloc(transform.position, _configProvider.EnemyConfig.ScanRadius, _colliders, layerMask: ~ignore);

            Transform target = null;
            
            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].TryGetComponent(out IDamageable damageable))
                {
                    if (_colliders[i].TryGetComponent(out BombController bombController))
                    {
                        target = bombController.transform;
                        break;
                    }
                }
            }

            _enemyMovement.SetTarget(target);
            _enemyStateMachine.ChangeState(EnemyStateType.Chase);
        }

        private void Update()
        {
            _enemyStateMachine.Update();
            _bombController.Process();
        }

        private void OnDestroy() => _enemyMovement.Destroy();
    }
}