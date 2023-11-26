using System;
using Services.Assets;

namespace Services.States
{
    public class PreWarmState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingScreenAssetProvider _loadingScreenAssetProvider;
        private readonly StartScreenAssetProvider _startScreenAssetProvider;
        private readonly ExplosionVFXPool _explosionVFXPool;
        private readonly NotificationService _notificationService;

        public PreWarmState(StateMachine stateMachine, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider, ExplosionVFXPool explosionVFXPool, NotificationService notificationService)
        {
            _stateMachine = stateMachine;
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
            _startScreenAssetProvider = startScreenAssetProvider;
            _explosionVFXPool = explosionVFXPool;
            _notificationService = notificationService;
        }

        public async void Enter()
        {
#if !UNITY_WEBGL
            Vibration.Init();
#endif

#if UNITY_ANDROID
            _notificationService.RequestNotificationPermission();
            _notificationService.RegisterNotificationChannel();
            _notificationService.SendNotification("Hello, it's me!", "It's time to play", DateTime.Now.AddSeconds(10));
#endif

            await _loadingScreenAssetProvider.LoadLoadingScreenAsset();
            await _startScreenAssetProvider.LoadStartUIAsset();
            _explosionVFXPool.CreatePool(20);
            _stateMachine.ChangeState(GameStateType.LoadData);
        }

        public void Exit() { }
    }
}