using UnityEngine;

public class RotateTowardsCenter : MonoBehaviour
{
    private void Awake()
    {
        Vector3 toTarget = Vector3.zero - transform.position;

        var rotation = Quaternion.LookRotation(Vector3.down, toTarget);

        rotation.x = 0;
        rotation.z = 0;

        transform.rotation = rotation;
    }
}