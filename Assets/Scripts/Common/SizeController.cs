using System;
using UnityEngine;

namespace Common
{
    public class SizeController : MonoBehaviour
    {
        public event Action<float> OnSizeChanged;
        [SerializeField, Range(1f, 10f)] private float sizeModifier;
        private float _currentSize = 1;

        public float CurrentSize
        {
            get => _currentSize;
            set
            {
                _currentSize = value;
                OnSizeChanged?.Invoke(_currentSize);
            }
        }

        public void IncreaseSize() => CurrentSize += sizeModifier;
    }
}