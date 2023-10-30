using Services.Assets;

namespace Services.States
{
    public class PreWarmState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingScreenAssetProvider _loadingScreenAssetProvider;
        private readonly StartScreenAssetProvider _startScreenAssetProvider;
        private readonly ExplosionVFXPool _explosionVFXPool;

        public PreWarmState(StateMachine stateMachine, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider, ExplosionVFXPool explosionVFXPool)
        {
            _stateMachine = stateMachine;
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
            _startScreenAssetProvider = startScreenAssetProvider;
            _explosionVFXPool = explosionVFXPool;
        }

        public async void Enter()
        {
            Vibration.Init();
            await _loadingScreenAssetProvider.LoadLoadingScreenAsset();
            await _startScreenAssetProvider.LoadStartUIAsset();
            _explosionVFXPool.CreatePool(20);
            _stateMachine.ChangeState(GameStateType.LoadData);
        }

        public void Exit() { }
    }
}