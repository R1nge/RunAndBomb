using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class RootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}