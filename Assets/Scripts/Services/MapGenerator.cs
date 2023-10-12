using Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class MapGenerator
    {
        private readonly IObjectResolver _objectResolver;
        private readonly Logger _logger;
        private readonly GeneratorData _generatorData;

        public MapGenerator(IObjectResolver objectResolver, Logger logger, GeneratorData generatorData)
        {
            _objectResolver = objectResolver;
            _logger = logger;
            _generatorData = generatorData;
        }

        public void Generate()
        {
            _logger.Log(this, $"X: {_generatorData.SizeX} Y: {_generatorData.SizeZ}");
            for (int x = 0; x < _generatorData.SizeX; x++)
            {
                for (int z = 0; z < _generatorData.SizeZ; z++)
                {
                    var position = new Vector3(x * _generatorData.PlatformSizeX, 0, z * _generatorData.PlatformSizeZ);
                    _objectResolver.Instantiate(_generatorData.Platform, position, Quaternion.identity);
                }
            }
        }
    }
}