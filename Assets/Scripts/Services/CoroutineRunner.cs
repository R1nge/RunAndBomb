using UnityEngine;

namespace Services
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void OnDestroy() => StopAllCoroutines();
    }
}