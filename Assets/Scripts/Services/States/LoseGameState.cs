using UnityEngine;

namespace Services.States
{
    public class LoseGameState : IGameState
    {
        public LoseGameState()
        {
        }

        public void Enter()
        {
            Debug.Log("Player has lost");
        }

        public void Exit()
        {
        }
    }
}