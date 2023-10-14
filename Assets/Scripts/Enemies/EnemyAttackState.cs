namespace Enemies
{
    public class EnemyAttackState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly EnemyAttack _enemyAttack;

        public EnemyAttackState(EnemyStateMachine enemyStateMachine, EnemyAttack enemyAttack)
        {
            _enemyStateMachine = enemyStateMachine;
            _enemyAttack = enemyAttack;
        }
        
        public void Enter()
        {
            _enemyAttack.Attack();
            _enemyStateMachine.ChangeState(EnemyStateType.Patrol);
        }

        public void Update() { }

        public void Exit() { }
    }
}