using System;
using Services.States;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public event Action<bool> PlayerHasDied;
        private StateMachine _stateMachine;
        private bool _isDead;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void Damage()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;

            PlayerHasDied?.Invoke(_isDead);
            _stateMachine.ChangeState(StateType.Lose);
        }
    }
}