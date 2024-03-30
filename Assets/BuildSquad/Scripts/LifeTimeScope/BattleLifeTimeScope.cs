using BuildSquad.Scripts.Entity.Scriptable;
using BuildSquad.Scripts.Presenter.Interface;
using BuildSquad.Scripts.UseCase.Data;
using BuildSquad.Scripts.View.Implement.Object;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.LifeTimeScope
{
    public class BattleLifeTimeScope : LifetimeScope
    {
        [SerializeField] private SquadScriptable squad;
        [SerializeField] private GroupObject groupObject;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(squad);
            
            // Viewをスクリプトで動的に生成する場合は、RegisterFactoryで登録する
            builder.RegisterFactory<GroupData, IGroupObject>(Instantiate);
        }
        
        private IGroupObject Instantiate(GroupData data)
        {
            var groupObjectInstance = Instantiate(groupObject);
            return groupObjectInstance;
        }
    }
}
