using System.Collections.Generic;

namespace Services.Maps
{
    public class PlatformDataHolder
    {
        private readonly List<Platform> _platforms = new();

        public IReadOnlyList<Platform> Platforms => _platforms;

        public void Add(Platform platform) => _platforms.Add(platform);

        public void Remove(Platform platform) => _platforms.Remove(platform);
    }
}