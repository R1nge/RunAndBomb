using System.Threading.Tasks;
using Services.Assets;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class ExplosionVFXFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ExplosionVFXAssetProvider _explosionVFXAssetProvider;

        private ExplosionVFXFactory(DiContainer diContainer, ExplosionVFXAssetProvider explosionVFXAssetProvider)
        {
            _diContainer = diContainer;
            _explosionVFXAssetProvider = explosionVFXAssetProvider;
        }

        public async Task<GameObject> Create()
        {
            GameObject vfxAsset = await _explosionVFXAssetProvider.LoadExplosionVFX();
            return _diContainer.InstantiatePrefab(vfxAsset);
        }
    }
}