using UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EnemySkinService _enemySkinService;
        private readonly EnemyCounter _enemyCounter;
        private readonly Transform[] _positions;

        public EnemyFactory(IObjectResolver objectResolver, EnemySkinService enemySkinService, EnemyCounter enemyCounter, Transform[] positions)
        {
            _objectResolver = objectResolver;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _positions = positions;
        }

        public void Create()
        {
            for (int i = 1; i < _positions.Length; i++)
            {
                var enemy = _objectResolver.Instantiate(_enemySkinService.GetRandomSkin(), _positions[i].position, Quaternion.identity);
                enemy.GetComponent<NicknameUI>().SetNickname(i.ToString());
                _enemyCounter.Increase();
            }
        }
    }
}