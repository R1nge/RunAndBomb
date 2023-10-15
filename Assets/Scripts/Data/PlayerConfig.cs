using Players;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private float speed;
        [SerializeField] private float gravity;

        public Player PlayerPrefab => playerPrefab;
        public Vector3 SpawnPosition => spawnPosition;
        public float Speed => speed;
        public float Gravity => gravity;
    }
}