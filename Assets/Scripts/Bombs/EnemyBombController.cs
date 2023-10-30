namespace Bombs
{
    public class EnemyBombController : BombController
    {
        public override void Process()
        {
            base.Process();
            
            if (CurrentTime <= 0)
            {
                ResetTimer();
            }
        }
    }
}