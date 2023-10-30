using System;

namespace Bombs
{
    public class PlayerBombController : BombController
    {
        public event Action OnTimerStarted, OnTimerEnded;
        public event Action<float, float> OnTimerChanged;
        private TrajectoryPredictor _trajectoryPredictor;

        protected override void Awake()
        {
            base.Awake();
            _trajectoryPredictor = GetComponent<TrajectoryPredictor>();
        }

        public override void Process()
        {
            base.Process();

            if (_canThrow)
            {
                _trajectoryPredictor.PredictTrajectory(BombProperties);
            }
            else
            {
                OnTimerStarted?.Invoke();

                OnTimerChanged?.Invoke(CurrentTime, throwInterval);

                if (CurrentTime <= 0)
                {
                    OnTimerEnded?.Invoke();
                    ResetTimer();
                }
            }
        }
    }
}