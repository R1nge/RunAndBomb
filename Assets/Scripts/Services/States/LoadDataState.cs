using System;
using Services.Data;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingService _loadingService;
        private readonly NotificationService _notificationService;


        public LoadDataState(StateMachine stateMachine, LoadingService loadingService, NotificationService notificationService)
        {
            _stateMachine = stateMachine;
            _loadingService = loadingService;
            _notificationService = notificationService;
        }

        public async void Enter()
        {
            await _loadingService.Load();
            
#if UNITY_ANDROID
            _notificationService.RequestNotificationPermission();
            _notificationService.RegisterNotificationChannel();
            _notificationService.SendNotification("Hello, it's me!", "It's time to play", DateTime.Now.AddDays(1));
#endif
            
            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}