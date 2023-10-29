using Cinemachine;
using UnityEngine;

namespace Services
{
    public class CameraService : MonoBehaviour
    {
        private CinemachineVirtualCamera _main;
        private CinemachineVirtualCamera _player;

        public void SetMainCamera(CinemachineVirtualCamera virtualCamera) => _main = virtualCamera;
        public void SetPlayerCamera(CinemachineVirtualCamera virtualCamera) => _player = virtualCamera;

        public void SwitchToMain() => _main.Priority = 1;

        public void SwitchToPlayer()
        {
            _main.Priority = 0;
            _player.Priority = 1;
        }
    }
}