using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class Boot : MonoBehaviour
    {
        private void Start() => SceneManager.LoadSceneAsync("Game");
    }
}