using Players;
using UnityEngine;

namespace Enemies
{
    public class EnemyCollisionDetector : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy otherEnemy))
            {
                enemy.OnTriggerEntered(other);
            }
            else if (other.TryGetComponent(out Player player))
            {
                enemy.OnTriggerEntered(other);
            }
        }
    }
}