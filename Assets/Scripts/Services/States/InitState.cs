using UnityEngine;

namespace Services.States
{
    public class InitState : IState
    {
        private PlayerSpawner _playerSpawner;

        public InitState(PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
        }
        
        public void Enter()
        {
            _playerSpawner.Spawn();
            Debug.Log("ENTER INIT");
        }

        public void Exit()
        {
            
        }
    }
}