using UnityEngine;

namespace Services.States
{
    public class LoseState : IState
    {
        public LoseState()
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