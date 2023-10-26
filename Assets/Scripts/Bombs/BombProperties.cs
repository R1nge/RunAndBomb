using UnityEngine;

namespace Bombs
{
    public struct BombProperties
    {
        public Vector3 Direction;
        public Vector3 InitialPosition;
        public float InitialSpeed;
        public float Mass;
        public float Drag;
        public Vector3 Gravity;
    }
}