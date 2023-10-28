using System;
using System.Collections;
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
            private set
            {
                _currentSize = value;
                OnSizeChanged?.Invoke(_currentSize);
            }
        }

        private void Start()
        {
            IncreaseSize();
        }

        public void IncreaseSize()
        {
            CurrentSize += sizeModifier;
            StartCoroutine(LerpFunction(CurrentSize, 2));
        }

        private IEnumerator LerpFunction(float endValue, float duration)
        {
            float time = 0;
            const float startValue = 1;
            Vector3 startScale = transform.localScale;
            while (time < duration)
            {
                _currentSize = Mathf.Lerp(startValue, endValue, time / duration);
                transform.localScale = startScale * _currentSize;
                time += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale * endValue;
            _currentSize = endValue;
        }
    }
}