using Services;
using UnityEngine;
using VContainer;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        private EnemyCounter _enemyCounter;

        [Inject]
        public void Inject(EnemyCounter enemyCounter) => _enemyCounter = enemyCounter;

        public void Damage() => Death();

        private void Death()
        {
            _enemyCounter.Decrease();
            
        }
    }
}