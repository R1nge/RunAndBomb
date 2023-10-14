using UnityEngine;

namespace Enemies
{
    public class EnemyCollisionDetector : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        private void OnTriggerEnter(Collider other) => enemy.OnTriggerEntered(other);
    }
}