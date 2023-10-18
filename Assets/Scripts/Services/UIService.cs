using Services.Factories;
using UIs;
using UnityEngine;

namespace Services
{
    public class UIService
    {
        private readonly LoadingScreenFactory _loadingScreenFactory;
        private readonly StartScreenFactory _startScreenFactory;
        private readonly GamePlayScreenFactory _gamePlayScreenFactory;
        private readonly WinScreenFactory _winScreenFactory;
        private readonly LoseScreenFactory _loseScreenFactory;

        private GameObject _previousScreen;

        private UIService(LoadingScreenFactory loadingScreenFactory, StartScreenFactory startScreenFactory,
            GamePlayScreenFactory gamePlayScreenFactory, WinScreenFactory winScreenFactory,
            LoseScreenFactory loseScreenFactory)
        {
            _loadingScreenFactory = loadingScreenFactory;
            _startScreenFactory = startScreenFactory;
            _gamePlayScreenFactory = gamePlayScreenFactory;
            _winScreenFactory = winScreenFactory;
            _loseScreenFactory = loseScreenFactory;
        }

        public LoadingScreen ShowLoadingScreen()
        {
            LoadingScreen screen = _loadingScreenFactory.Create();
            _previousScreen = screen.gameObject;
            return screen;
        }

        public StartUI ShowStartScreen()
        {
            Object.Destroy(_previousScreen);

            StartUI screen = _startScreenFactory.Create();
            _previousScreen = screen.gameObject;

            return screen;
        }

        public InGameUI ShowGameScreen()
        {
            Object.Destroy(_previousScreen);

            InGameUI screen = _gamePlayScreenFactory.Create();
            _previousScreen = screen.gameObject;

            return screen;
        }

        public WinUI ShowWinScreen()
        {
            Object.Destroy(_previousScreen);

            WinUI screen = _winScreenFactory.Create();
            _previousScreen = screen.gameObject;

            return screen;
        }

        public LoseUI ShowLoseScreen()
        {
            Object.Destroy(_previousScreen);

            LoseUI screen = _loseScreenFactory.Create();
            _previousScreen = screen.gameObject;

            return screen;
        }
    }
}