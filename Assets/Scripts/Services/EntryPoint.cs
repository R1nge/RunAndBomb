using Services.States;
using UnityEngine;
using Zenject;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Start()
        {
            Application.targetFrameRate = 999999;
            QualitySettings.vSyncCount = 0;
            
            _stateMachine.ChangeState(GameStateType.LoadData);
        }
    }
}