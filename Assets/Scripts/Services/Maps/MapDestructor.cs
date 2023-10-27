using System;
using System.Collections;
using Services.Data;
using Unity.AI.Navigation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Maps
{
    public class MapDestructor
    {
        public event Action OnTileDestroyed;
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
                yield return new WaitForSeconds(_configProvider.MapConfig.DestroyInterval);
                _platformDataHolder.Platforms[i].Drop();
                yield return new WaitForSeconds(.1f);
                _navMeshSurface.BuildNavMesh();
                _platformDataHolder.Remove(_platformDataHolder.Platforms[i]);
                OnTileDestroyed?.Invoke();
            }

            yield return new WaitForSeconds(.1f);
            _navMeshSurface.BuildNavMesh();
        }

        public void DestroyMap()
        {
            for (int i = 0; i < _platformDataHolder.Platforms.Count ; i++)
            {
                if(_platformDataHolder.Platforms[i].gameObject == null) continue;
                Object.Destroy(_platformDataHolder.Platforms[i].gameObject);
            }

            _platformDataHolder.Clear();
        }
    }
}