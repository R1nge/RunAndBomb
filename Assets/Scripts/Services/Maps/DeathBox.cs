using UnityEngine;

namespace Services.Maps
{
    public class DeathBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage();
            }
        }
    }
}