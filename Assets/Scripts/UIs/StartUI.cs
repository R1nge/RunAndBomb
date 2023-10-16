using Services;
using Services.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UIs
{
    public class StartUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Button start;
        private StateMachine _stateMachine;
        private PlayerDataHolder _playerDataHolder;

        [Inject]
        private void Inject(StateMachine stateMachine, PlayerDataHolder playerDataHolder)
        {
            _stateMachine = stateMachine;
            _playerDataHolder = playerDataHolder;
        }

        private void Start()
        {
            SetLoadedNickname();
            nameInputField.onEndEdit.AddListener(SaveNickname);
            start.onClick.AddListener(StartGame);
        }

        private void SetLoadedNickname() => nameInputField.text = _playerDataHolder.PlayerStatisticsModel.Name;

        private void SaveNickname(string nickname) => _playerDataHolder.PlayerStatisticsModel.Name = nickname;

        private void StartGame() => _stateMachine.ChangeState(GameStateType.Game);

        private void OnDestroy()
        {
            nameInputField.onEndEdit.RemoveAllListeners();
            start.onClick.RemoveAllListeners();
        }
    }
}