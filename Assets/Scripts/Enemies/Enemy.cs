using Bombs;
using Players;
using Services;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private EnemyStateType _currentState;
        private EnemyCounter _enemyCounter;
        private EnemyMovement _enemyMovement;
        private EnemyAttack _enemyAttack;
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;
        private BombController _bombController;

        //Create a state machine
        
        [Inject]
        public void Inject(EnemyCounter enemyCounter) => _enemyCounter = enemyCounter;

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _bombController = GetComponent<BombController>();

            _enemyMovement = new EnemyMovement(transform, _navMeshAgent);
            _enemyAttack = new EnemyAttack(_bombController, _enemyAnimator);
        }

        private void Update()
        {
            switch (_currentState)
            {
                case EnemyStateType.Patrol:
                    Patrol();
                    break;
                case EnemyStateType.Chase:
                    Chase();
                    break;
                case EnemyStateType.Attack:
                    Attack();
                    break;
                case EnemyStateType.Death:
                    Die();
                    break;
            }

            print($"[{gameObject.name}] State: {_currentState}");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_currentState != EnemyStateType.Patrol)
            {
                return;
            }

            if (other.TryGetComponent(out Player player))
            {
                _enemyMovement.SetTarget(player.transform);
                _currentState = EnemyStateType.Chase;
                return;
            }

            if (other.TryGetComponent(out Enemy enemy))
            {
                _enemyMovement.SetTarget(enemy.transform);
                _currentState = EnemyStateType.Chase;
            }
        }

        private void Patrol() => _enemyMovement.Patrol();

        private void Chase() => _enemyMovement.Chase();

        //TODO: calculate and pass attack modifier
        private void Attack() => _enemyAttack.Attack();

        private void Die()
        {
            _enemyCounter.Decrease();
            //TODO: create a ragdoll controller
            Destroy(this);
        }

        public void Damage() => _currentState = EnemyStateType.Death;
    }
}