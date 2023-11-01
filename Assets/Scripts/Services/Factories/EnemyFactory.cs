using System.Threading.Tasks;
using Enemies;
using Services.Assets;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class EnemyFactory
    {
        private readonly DiContainer _container;
        private readonly EnemyAssetProvider _enemyAssetProvider;
        private readonly EnemyCounter _enemyCounter;
        private readonly RestartService _restartService;

        private EnemyFactory(DiContainer container, EnemyAssetProvider enemyAssetProvider, EnemyCounter enemyCounter, RestartService restartService)
        {
            _container = container;
            _enemyAssetProvider = enemyAssetProvider;
            _enemyCounter = enemyCounter;
            _restartService = restartService;
        }

        public async Task<Enemy> Create()
        {
            Enemy skin = await _enemyAssetProvider.GetRandomSkin();
            Enemy enemy = _container.InstantiatePrefabForComponent<Enemy>(skin);
            _restartService.AddEnemy(enemy);
            enemy.GetComponent<NicknameUI>().SetNickname(NameGenerator.GenerateName());
            _enemyCounter.Increase();
            return enemy;
        }
    }
}