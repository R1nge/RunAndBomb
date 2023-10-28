using Cinemachine;
using UnityEngine;

namespace Services
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera mainMenu;

        private CinemachineVirtualCamera _player;
        private CinemachineVirtualCamera _win;

        public void SetPlayerCamera(CinemachineVirtualCamera virtualCamera) => _player = virtualCamera;
        public void SetWinCamera(CinemachineVirtualCamera virtualCamera) => _win = virtualCamera;


        public void SwitchToMain() => mainMenu.Priority = 10;

        public void SwitchToPlayer()
        {
            mainMenu.Priority = 0;
            _win.Priority = 0;
            _player.Priority = 1;
        }

        public void SwitchToWin()
        {
            mainMenu.Priority = 0;
            _player.Priority = 0;
            _win.Priority = 1;
        }
    }
}