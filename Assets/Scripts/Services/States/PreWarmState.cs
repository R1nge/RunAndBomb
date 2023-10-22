using Services.Assets;

namespace Services.States
{
    public class PreWarmState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingScreenAssetProvider _loadingScreenAssetProvider;
        private readonly StartScreenAssetProvider _startScreenAssetProvider;

        public PreWarmState(StateMachine stateMachine, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider)
        {
            _stateMachine = stateMachine;
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
            _startScreenAssetProvider = startScreenAssetProvider;
        }

        public async void Enter()
        {
            await _loadingScreenAssetProvider.LoadLoadingScreenAsset();
            await _startScreenAssetProvider.LoadStartUIAsset();
            _stateMachine.ChangeState(GameStateType.LoadData);
        }

        public void Exit() { }
    }
}