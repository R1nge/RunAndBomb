using Players;
using UnityEngine;

namespace Services.Maps
{
    public class DeathBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.TakeDamage();
            }
        }
    }
}