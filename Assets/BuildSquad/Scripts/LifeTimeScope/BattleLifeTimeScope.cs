using BuildSquad.Scripts.Entity.Scriptable;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.LifeTimeScope
{
    public class BattleLifeTimeScope : LifetimeScope
    {
        public SquadScriptable squad;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(squad);
        }
    }
}
