using System.Collections;
using UnityEngine;

namespace UIs
{
    public class ButtonScalingAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 maxScale;
        [SerializeField] private bool loop;
        [SerializeField] private float duration;
        private Vector3 _minScale;
        
        private IEnumerator Start()
        {
            _minScale = transform.localScale;
            while (loop)
            {
                yield return Lerp(_minScale, maxScale, duration);
                yield return Lerp(maxScale, _minScale, duration);
            }
        }

        private IEnumerator Lerp(Vector3 from, Vector3 to, float duration)
        {
            float currentTime = 0;
            float rate = 1f / duration;
            while (currentTime < 1)
            {
                currentTime += Time.deltaTime * rate;
                transform.localScale = Vector3.Lerp(from, to, currentTime);
                yield return null;
            }
        }
    }
}