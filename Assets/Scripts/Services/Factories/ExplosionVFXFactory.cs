using System.Threading.Tasks;
using Services.Assets;
using UnityEngine;

namespace Services.Factories
{
    public class ExplosionVFXFactory
    {
        private readonly ExplosionVFXAssetProvider _explosionVFXAssetProvider;

        private ExplosionVFXFactory(ExplosionVFXAssetProvider explosionVFXAssetProvider)
        {
            _explosionVFXAssetProvider = explosionVFXAssetProvider;
        }
        
        public async Task<GameObject> Create()
        {
            Task<GameObject> screen = _explosionVFXAssetProvider.LoadExplosionAsset();
            await screen;
            return Object.Instantiate(screen.Result);
        }
    }
}