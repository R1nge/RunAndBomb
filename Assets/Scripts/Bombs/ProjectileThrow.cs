using UnityEngine;

namespace Bombs
{
    [RequireComponent(typeof(TrajectoryPredictor))]
    public class ProjectileThrow : MonoBehaviour
    {
        [SerializeField] private Transform bombSpawnPoint;
        [SerializeField] private Rigidbody objectToThrow;
        [SerializeField, Range(0.0f, 50.0f)] private float force;

        private TrajectoryPredictor _trajectoryPredictor;

        private BombProperties _bombProperties;

        private void Awake()
        {
            _trajectoryPredictor = GetComponent<TrajectoryPredictor>();

            var rigidbody = objectToThrow.GetComponent<Rigidbody>();
            
            _bombProperties = new BombProperties
            {
                InitialSpeed = force,
                Mass = rigidbody.mass,
                Drag = rigidbody.drag
            };
        }

        private void Update() => Predict();

        private void Predict()
        {
            _bombProperties.Direction = bombSpawnPoint.transform.forward;
            _bombProperties.InitialPosition = bombSpawnPoint.transform.position;
            _trajectoryPredictor.PredictTrajectory(_bombProperties);
        }

        private void Throw()
        {
            //Rigidbody thrownObject = Instantiate(objectToThrow, startPosition.position, Quaternion.identity);
            //thrownObject.AddForce(startPosition.forward * force, ForceMode.Impulse);
        }
    }
}