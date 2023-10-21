using Services.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIs
{
    public class LoseUI : MonoBehaviour
    {
        [SerializeField] private Button button;
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Awake() => button.onClick.AddListener(Restart);

        private void Restart() => _stateMachine.ChangeState(GameStateType.Reset);
    }
}