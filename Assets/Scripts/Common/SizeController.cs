using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class SizeController : MonoBehaviour
    {
        public event Action<float> OnSizeChanged;
        [SerializeField, Range(0f, .5f)] private float sizeModifier;
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
                float size = Mathf.Lerp(startValue, endValue, time / duration);
                transform.localScale = startScale * size;
                time += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale * endValue;
        }
    }
}