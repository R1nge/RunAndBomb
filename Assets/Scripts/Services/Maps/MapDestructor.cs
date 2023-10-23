using System.Collections;
using Services.Data;
using Unity.AI.Navigation;
using UnityEngine;

namespace Services.Maps
{
    public class MapDestructor
    {
        private readonly ConfigProvider _configProvider;
        private readonly PlatformDataHolder _platformDataHolder;
        private NavMeshSurface _navMeshSurface;

        private MapDestructor(ConfigProvider configProvider, PlatformDataHolder platformDataHolder)
        {
            _configProvider = configProvider;
            _platformDataHolder = platformDataHolder;
        }

        public IEnumerator Destroy()
        {
            _navMeshSurface = _platformDataHolder.Platforms[0].GetComponentInChildren<NavMeshSurface>();
            for (int i = _platformDataHolder.Platforms.Count - 1; i > 0; i--)
            {
                yield return new WaitForSeconds(3f);
                _platformDataHolder.Platforms[i].Drop();
                yield return new WaitForSeconds(.1f);
                _navMeshSurface.BuildNavMesh();
                _platformDataHolder.Remove(_platformDataHolder.Platforms[i]);
            }
        }
    }
}