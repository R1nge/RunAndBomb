using Services.Factories;
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

        private UIService(LoadingScreenFactory loadingScreenFactory, StartScreenFactory startScreenFactory, GamePlayScreenFactory gamePlayScreenFactory, WinScreenFactory winScreenFactory, LoseScreenFactory loseScreenFactory)
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

        public void ShowStartScreen()
        {
            Object.Destroy(_previousScreen);
            _previousScreen = _startScreenFactory.Create().gameObject;
        }

        public void ShowGameScreen()
        {
            Object.Destroy(_previousScreen);
            _previousScreen = _gamePlayScreenFactory.Create().gameObject;
        }

        public void ShowWinScreen()
        {
            Object.Destroy(_previousScreen);
            _previousScreen = _winScreenFactory.Create().gameObject;
        }

        public void ShowLoseScreen()
        {
            Object.Destroy(_previousScreen);
            _previousScreen = _loseScreenFactory.Create().gameObject;
        }
    }
}