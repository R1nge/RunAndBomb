﻿using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "BombConfig", menuName = "Configs/Bomb Config")]
    public class BombConfig : ScriptableObject
    {
        [SerializeField] private float mass;
        [SerializeField] private float drag;
        [SerializeField] private Vector3 gravity;
        [SerializeField] private AssetReferenceGameObject explosionVFX;

        public float Mass => mass;
        public float Drag => drag;
        public Vector3 Gravity => gravity;
        public AssetReferenceGameObject ExplosionVFX => explosionVFX;
    }
}