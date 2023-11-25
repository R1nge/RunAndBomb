using Players;
using Services.Assets;
using Services.Data;
using Services.Data.Player;
using Services.Data.Settings;
using Services.Factories;
using Services.Maps;

namespace Services.States
{
    public class GameStatesFactory
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly UIService _uiService;
        private readonly PlayerFactory _playerFactory;
        private readonly EnemySpawner _enemySpawner;
        private readonly MapService _mapService;
        private readonly RestartService _restartService;
        private readonly LoadingScreenAssetProvider _loadingScreenAssetProvider;
        private readonly StartScreenAssetProvider _startScreenAssetProvider;
        private readonly InputService _inputService;
        private readonly CameraService _cameraService;
        private readonly PlayerReferenceHolder _playerReferenceHolder;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly ConfigProvider _configProvider;
        private readonly ExplosionVFXPool _explosionVFXPool;
        private readonly LoadingService _loadingService;

        private GameStatesFactory(IPlayerDataService playerDataService, CoroutineRunner coroutineRunner, UIService uiService, PlayerFactory playerFactory, EnemySpawner enemySpawner, MapService mapService, RestartService restartService, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider, InputService inputService, CameraService cameraService, PlayerReferenceHolder playerReferenceHolder, SpawnPositionsProvider spawnPositionsProvider, ConfigProvider configProvider, ExplosionVFXPool explosionVFXPool, LoadingService loadingService)
        {
            _playerDataService = playerDataService;
            _coroutineRunner = coroutineRunner;
            _uiService = uiService;
            _playerFactory = playerFactory;
            _enemySpawner = enemySpawner;
            _mapService = mapService;
            _restartService = restartService;
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
            _startScreenAssetProvider = startScreenAssetProvider;
            _inputService = inputService;
            _cameraService = cameraService;
            _playerReferenceHolder = playerReferenceHolder;
            _spawnPositionsProvider = spawnPositionsProvider;
            _configProvider = configProvider;
            _explosionVFXPool = explosionVFXPool;
            _loadingService = loadingService;
        }

        public IGameState CreatePreWarmState(StateMachine stateMachine)
        {
            return new PreWarmState(stateMachine, _loadingScreenAssetProvider, _startScreenAssetProvider, _explosionVFXPool);
        }

        public IGameState CreateLoadDataState(StateMachine stateMachine)
        {
            return new LoadDataState(stateMachine, _loadingService);
        }

        public IGameState CreateResetState(StateMachine stateMachine)
        {
            return new ResetState(stateMachine, _coroutineRunner, _restartService, _mapService);
        }

        public IGameState CreateInitGameState(StateMachine stateMachine)
        {
            return new InitGameState(_uiService, _playerDataService, _cameraService, _mapService, _playerFactory, _spawnPositionsProvider, _configProvider, _playerReferenceHolder);
        }

        public IGameState CreateGameState(StateMachine stateMachine)
        {
            return new GameState(_enemySpawner, _uiService, _mapService, _coroutineRunner, _inputService, _cameraService, _playerReferenceHolder);
        }

        public IGameState CreateWinGameState(StateMachine stateMachine)
        {
            return new WinGameState(_playerDataService, _uiService, _cameraService, _playerReferenceHolder);
        }

        public IGameState CreateLoseGameState(StateMachine stateMachine)
        {
            return new LoseGameState(_uiService);
        }
    }
}