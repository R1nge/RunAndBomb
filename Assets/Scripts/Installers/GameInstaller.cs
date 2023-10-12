using Services;
using Services.States;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EnemyCounter>(Lifetime.Singleton);
            builder.Register<StateMachine>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<EntryPoint>();
        }
    }
}