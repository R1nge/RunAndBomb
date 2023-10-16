using UnityEngine;

namespace Services
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void StopCoroutines() => StopAllCoroutines();
        
        private void OnDestroy() => StopAllCoroutines();
    }
}