using Services.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UIs
{
    public class StartUI : MonoBehaviour
    {
        [SerializeField] private Button start;
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Start() => start.onClick.AddListener(StartGame);

        private void StartGame() => _stateMachine.ChangeState(GameStateType.Game);

        private void OnDestroy() => start.onClick.RemoveAllListeners();
    }
}