using Data;

namespace Services
{
    public class MapGenerator
    {
        private readonly Logger _logger;
        private readonly GeneratorData _generatorData;

        public MapGenerator(Logger logger, GeneratorData generatorData)
        {
            _logger = logger;
            _generatorData = generatorData;
        }

        public void Generate()
        {
            _logger.Log(this, $"X: {_generatorData.SizeX} Y: {_generatorData.SizeY}");
        }
    }
}