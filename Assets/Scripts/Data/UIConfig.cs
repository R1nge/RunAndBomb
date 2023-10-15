using UIs;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "UI Config")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private StartUI startScreen;
        [SerializeField] private InGameUI gamePlayScreen;
        [SerializeField] private WinUI win;
        [SerializeField] private LoseUI lose;

        public StartUI StartScreen => startScreen;
        public InGameUI GamePlayScreen => gamePlayScreen;
        public WinUI Win => win;
        public LoseUI Lose => lose;
    }
}