using Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class MapGenerator
    {
        private readonly IObjectResolver _objectResolver;
        private readonly GeneratorConfig _generatorConfig;

        public MapGenerator(IObjectResolver objectResolver, GeneratorConfig generatorConfig)
        {
            _objectResolver = objectResolver;
            _generatorConfig = generatorConfig;
        }

        public void Generate()
        {
            for (int x = 0; x < _generatorConfig.SizeX; x++)
            {
                for (int z = 0; z < _generatorConfig.SizeZ; z++)
                {
                    var position = new Vector3(x * _generatorConfig.PlatformSizeX, 0, z * _generatorConfig.PlatformSizeZ);
                    _objectResolver.Instantiate(_generatorConfig.Platform, position, Quaternion.identity);
                }
            }
        }
    }
}