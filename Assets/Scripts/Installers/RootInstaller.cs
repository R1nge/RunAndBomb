using Services;
using Services.States;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class RootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StateMachine>(Lifetime.Singleton).AsSelf();
            builder.RegisterComponentInHierarchy<EntryPoint>().AsSelf();
        }
    }
}