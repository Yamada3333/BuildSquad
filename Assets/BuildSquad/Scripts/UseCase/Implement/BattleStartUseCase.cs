using BuildSquad.Scripts.Entity.Scriptable;
using BuildSquad.Scripts.UseCase.Data;
using BuildSquad.Scripts.UseCase.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.UseCase.Implement
{
    public class BattleStartUseCase : IStartable
    {
        private readonly SquadScriptable _squadScriptable;
        private readonly IBattleStartPresenter _battlePresenter;
        
        [Inject]
        public BattleStartUseCase(SquadScriptable squadScriptable, IBattleStartPresenter battlePresenter)
        {
            _squadScriptable = squadScriptable;
            
            if (!_squadScriptable.CheckGroup())
            {
                Debug.LogError("ユニットが３つ揃っていません");
            }
            
            _battlePresenter = battlePresenter;
        }

        public void Start()
        {
            Debug.Log("バトルスタート");
            foreach (var _ in _squadScriptable.playerGroups)
            {
                var unitData = new GroupData();
                _battlePresenter.InstantiateUnit(unitData);
            }
            
            foreach (var _ in _squadScriptable.enemyGroups)
            {
                var unitData = new GroupData();
                _battlePresenter.InstantiateUnit(unitData);
            }
        }
    }
}
