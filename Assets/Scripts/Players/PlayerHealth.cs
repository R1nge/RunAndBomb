using Services.States;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void Damage() => _stateMachine.ChangeState(StateType.Lose);
    }
}