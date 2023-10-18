using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider loading;

    public void Destroy() => Destroy(gameObject);

    public void UpdatePercent(int current, int total) => loading.value = (float)current / total;
}