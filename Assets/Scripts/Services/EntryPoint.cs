using Services.States;
using UnityEngine;
using VContainer;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Start() => _stateMachine.ChangeState(GameStateType.LoadData);
    }
}