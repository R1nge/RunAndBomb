﻿using UnityEngine;

namespace Bombs
{
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryPredictor : MonoBehaviour
    {
        private LineRenderer _trajectoryLine;

        [SerializeField] private LayerMask ignore;

        [SerializeField, Tooltip("The marker will show where the projectile will hit")]
        private Transform hitMarker;

        [SerializeField, Range(10, 100), Tooltip("The maximum number of points the LineRenderer can have")]
        private int maxPoints = 50;

        [SerializeField, Range(0.01f, 0.5f), Tooltip("The time increment used to calculate the trajectory")]
        private float increment = 0.025f;

        [SerializeField, Range(1.05f, 2f),
         Tooltip(
             "The raycast overlap between points in the trajectory, this is a multiplier of the length between points. 2 = twice as long")]
        private float rayOverlap = 1.1f;

        private void Awake() => _trajectoryLine = GetComponent<LineRenderer>();

        private void Start() => SetTrajectoryVisible(true);

        public void PredictTrajectory(BombProperties projectile)
        {
            Vector3 velocity = projectile.Direction * (projectile.InitialSpeed / projectile.Mass);
            Vector3 position = projectile.InitialPosition;

            UpdateLineRender(maxPoints, (0, position));

            for (int i = 1; i < maxPoints; i++)
            {
                // Estimate velocity and update next predicted position
                velocity = CalculateNewVelocity(velocity, projectile.Drag, increment, projectile.Gravity);
                Vector3 nextPosition = position + velocity * increment;

                // Overlap our rays by small margin to ensure we never miss a surface
                float overlap = Vector3.Distance(position, nextPosition) * rayOverlap;

                //When hitting a surface show the surface marker and stop updating our line
                if (Physics.Raycast(position, velocity.normalized, out RaycastHit hit, overlap, ~ignore, QueryTriggerInteraction.Ignore))
                {
                    UpdateLineRender(i, (i - 1, hit.point));
                    MoveHitMarker(hit);
                    break;
                }

                //If nothing is hit, continue rendering the arc without a visual marker
                hitMarker.gameObject.SetActive(false);
                position = nextPosition;
                UpdateLineRender(maxPoints, (i, position)); //Unnecessary to set count here, but not harmful
            }
        }

        /// <summary>
        /// Allows us to set line count and an individual position at the same time
        /// </summary>
        /// <param name="count">Number of points in our line</param>
        /// <param name="pointPos">The position of an individual point</param>
        private void UpdateLineRender(int count, (int point, Vector3 pos) pointPos)
        {
            _trajectoryLine.positionCount = count;
            _trajectoryLine.SetPosition(pointPos.point, pointPos.pos);
        }

        private Vector3 CalculateNewVelocity(Vector3 velocity, float drag, float increment, Vector3 gravity)
        {
            velocity += gravity * increment;
            velocity *= Mathf.Clamp01(1f - drag * increment);
            return velocity;
        }

        private void MoveHitMarker(RaycastHit hit)
        {
            hitMarker.gameObject.SetActive(true);

            // Offset marker from surface
            const float offset = 0.15f;
            hitMarker.position = hit.point + hit.normal * offset;
            hitMarker.LookAt(hit.normal);
        }

        public void SetTrajectoryVisible(bool visible)
        {
            if (_trajectoryLine.enabled == visible || hitMarker.gameObject.activeInHierarchy == visible) return;
            _trajectoryLine.enabled = visible;
            hitMarker.gameObject.SetActive(visible);
        }
    }
}