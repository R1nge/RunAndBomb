using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}