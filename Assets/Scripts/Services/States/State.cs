namespace Services.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}