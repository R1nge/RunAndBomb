using UIs;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "UI Config")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private StartUI startScreen;
        [SerializeField] private InGameUI gamePlayScreen;
        [SerializeField] private EndUI win;
        [SerializeField] private EndUI lose;

        public StartUI StartScreen => startScreen;
        public InGameUI GamePlayScreen => gamePlayScreen;
        public EndUI Win => win;
        public EndUI Lose => lose;
    }
}