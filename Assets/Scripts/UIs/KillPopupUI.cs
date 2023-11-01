using System.Collections;
using UnityEngine;

namespace UIs
{
    public class KillPopupUI : MonoBehaviour
    {
        [SerializeField] private float scaleLerpDuration, rotationLerpDuration; 
        
        public IEnumerator Show()
        {
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            yield return StartCoroutine(LerpScale(1, scaleLerpDuration));
            yield return StartCoroutine(LerpRotation(new Vector3(0, 0, -5), rotationLerpDuration));
            yield return StartCoroutine(LerpRotation(new Vector3(0, 0, 5), rotationLerpDuration));
            yield return StartCoroutine(LerpRotation(new Vector3(0, 0, -5), rotationLerpDuration));
            yield return StartCoroutine(LerpRotation(new Vector3(0, 0, 5), rotationLerpDuration));
            yield return StartCoroutine(LerpScale( 0, scaleLerpDuration));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private IEnumerator LerpScale(float multiplier, float duration)
        {
            Vector3 scale = Vector3.one;
            scale *= multiplier;
            while (transform.localScale != scale) {
                transform.localScale = Vector3.MoveTowards(transform.localScale, scale, Time.deltaTime * 1 / duration);
                yield return null;
            }
        }

        private IEnumerator LerpRotation(Vector3 endValue, float duration)
        {
            float time = 0;
            Quaternion startValue = transform.rotation;
            while (time < duration)
            {
                transform.rotation = Quaternion.Lerp(startValue, Quaternion.Euler(endValue), time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            
            transform.rotation = Quaternion.Euler(endValue);
        }
    }
}