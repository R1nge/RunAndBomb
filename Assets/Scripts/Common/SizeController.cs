using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class SizeController : MonoBehaviour
    {
        public event Action<float> OnSizeChanged;
        [SerializeField, Range(0f, 2f)] private float sizeModifier;
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
            print($"CurrentSize: {CurrentSize}");
            StartCoroutine(LerpFunction(CurrentSize, 2));
        }

        private IEnumerator LerpFunction(float endValue, float duration)
        {
            float time = 0;
            const float startValue = 1;
            Vector3 startScale = transform.localScale;
            float size = 0;
            while (time < duration)
            {
                size = Mathf.Lerp(startValue, endValue, time / duration);
                transform.localScale = startScale * size;
                time += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale * endValue;
            size = endValue;
            
            print($"CurrentSize: {CurrentSize}");
        }
    }
}