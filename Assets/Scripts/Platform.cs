using Unity.AI.Navigation;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private NavMeshSurface _meshSurface;

    private void Awake()
    {
        _meshSurface = GetComponent<NavMeshSurface>();
    }

    private void OnDisable()
    {
        print("DISABLE");
        _meshSurface.BuildNavMesh();
    }

    private void OnDestroy()
    {
        print("DESTROY");
        _meshSurface.BuildNavMesh();
    }
}