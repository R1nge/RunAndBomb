namespace Enemies.States
{
    public class EnemyPatrolState : IEnemyState
    {
        private readonly EnemyMovement _enemyMovement;

        public EnemyPatrolState(EnemyMovement enemyMovement) => _enemyMovement = enemyMovement;

        public void Enter() { }

        public void Update() => _enemyMovement.Patrol();

        public void Exit() { }
    }
}