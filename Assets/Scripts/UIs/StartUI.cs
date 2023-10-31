using Services.Data;
using Services.Data.Player;
using Services.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIs
{
    public class StartUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Button start;
        private StateMachine _stateMachine;
        private IPlayerDataService _playerDataService;

        [Inject]
        private void Inject(StateMachine stateMachine, IPlayerDataService playerDataService)
        {
            _stateMachine = stateMachine;
            _playerDataService = playerDataService;
        }

        public void Init()
        {
            SetLoadedNickname();
            nameInputField.onEndEdit.AddListener(SaveNickname);
            start.onClick.AddListener(StartGame);
        }

        private void SetLoadedNickname() => nameInputField.text = _playerDataService.Model.Name;

        private void SaveNickname(string nickname) => _playerDataService.Model.Name = nickname;

        private void StartGame() => _stateMachine.ChangeState(GameStateType.Game);

        private void OnDestroy()
        {
            nameInputField.onEndEdit.RemoveAllListeners();
            start.onClick.RemoveAllListeners();
        }
    }
}