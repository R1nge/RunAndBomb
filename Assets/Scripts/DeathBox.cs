using Players;
using Services.States;
using UnityEngine;
using VContainer;

public class DeathBox : MonoBehaviour
{
    private StateMachine _stateMachine;

    [Inject]
    private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _stateMachine.ChangeState(GameStateType.Lose);
        }
    }
}