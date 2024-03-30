using System;
using BuildSquad.Scripts.Presenter.Interface;
using BuildSquad.Scripts.UseCase.Data;
using BuildSquad.Scripts.UseCase.Interface;
using VContainer;

namespace BuildSquad.Scripts.Presenter.Implement
{
    public class BattleStartPresenter : IBattleStartPresenter
    {
        private readonly Func<GroupData, IGroupObject> _group;
        
        [Inject]
        public BattleStartPresenter(Func<GroupData, IGroupObject> group)
        {
            _group = group;
        }
        
        public void InstantiateUnit(GroupData groupData)
        {
            var group = _group.Invoke(groupData);
        }
    }
}
