using Bombs;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class ThrowTimerUI : MonoBehaviour
    {
        [SerializeField] private GameObject timerParent;
        [SerializeField] private Image timerRadial;
        private BombController _bombController;

        private void Awake()
        {
            _bombController = GetComponent<BombController>();
            _bombController.OnTimerStarted += Show;
            _bombController.OnTimerEnded += Hide;
            _bombController.OnTimerChanged += UpdateSlider;

            timerParent.SetActive(false);
        }

        private void UpdateSlider(float time, float totalTime) => timerRadial.fillAmount = time / totalTime;

        public void Hide() => timerParent.SetActive(false);

        private void Show() => timerParent.SetActive(true);

        private void OnDestroy()
        {
            _bombController.OnTimerStarted -= Show;
            _bombController.OnTimerEnded -= Hide;
            _bombController.OnTimerChanged -= UpdateSlider;
        }
    }
}