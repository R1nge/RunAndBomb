using Data;
using UnityEngine;

namespace Services.Data
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private EnemySkinsConfig enemySkinsConfig;
        [SerializeField] private BombSkinsConfig bombSkinsConfig;
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private MapConfig mapConfig;

        public PlayerConfig PlayerConfig => playerConfig;
        public EnemyConfig EnemyConfig => enemyConfig;
        public EnemySkinsConfig EnemySkinsConfig => enemySkinsConfig;
        public BombSkinsConfig BombSkinsConfig => bombSkinsConfig;
        public UIConfig UIConfig => uiConfig;
        public MapConfig MapConfig => mapConfig;
    }
}