using UnityEngine;

namespace Enemies
{
    public class EnemyChaseState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly EnemyMovement _enemyMovement;

        public EnemyChaseState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement)
        {
            _enemyStateMachine = enemyStateMachine;
            _enemyMovement = enemyMovement;
        }

        public void Enter() { }

        public void Update()
        {
            _enemyMovement.Chase();

            if (_enemyMovement.IsInAttackRange())
            {
                _enemyStateMachine.ChangeState(EnemyStateType.Attack);
            }
            
            Debug.Log("[EnemyChaseState] Update");
        }

        public void Exit() { Debug.Log("[EnemyChaseState] Exit");}
    }
}