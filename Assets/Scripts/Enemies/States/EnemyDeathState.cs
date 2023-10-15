namespace Enemies.States
{
    public class EnemyDeathState : IEnemyState
    {
        private readonly EnemyDeathController _enemyDeathController;
        
        public EnemyDeathState(EnemyDeathController enemyDeathController) => _enemyDeathController = enemyDeathController;

        public void Enter() => _enemyDeathController.Die();

        public void Update() { }

        public void Exit() { }
    }
}