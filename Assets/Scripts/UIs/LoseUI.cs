using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIs
{
    public class LoseUI : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake() => button.onClick.AddListener(Restart);

        private void Restart() => SceneManager.LoadSceneAsync("Game");
    }
}