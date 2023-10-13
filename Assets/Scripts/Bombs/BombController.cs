using System;
using UnityEngine;

namespace Bombs
{
    public class BombController : MonoBehaviour
    {
        public event Action<bool> BombHasBeenThrown;
        [SerializeField] private Bomb bomb;
        
        
        //TODO: spawn a bomb when the player has stopped moving
    }
}