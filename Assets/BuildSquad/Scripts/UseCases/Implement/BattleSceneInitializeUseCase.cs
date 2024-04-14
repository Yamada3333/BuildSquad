using BuildSquad.Scripts.Entities.Scriptable;
using BuildSquad.Scripts.UseCases.Interface.Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.UseCases.Implement
{
    public class BattleSceneInitializeUseCase : IStartable
    {
        private readonly SaveDataScriptable _saveData;
        private readonly UnitSetUpUseCase _unitSetUpUseCase;
        private readonly IBattleSceneInitializePresenter _presenter;

        [Inject]
        public BattleSceneInitializeUseCase(SaveDataScriptable saveData, UnitSetUpUseCase unitSetUpUseCase, IBattleSceneInitializePresenter presenter)
        {
            _saveData = saveData;
            _unitSetUpUseCase = unitSetUpUseCase;
            _presenter = presenter;
        }

        public void Start()
        {
            Debug.Log("シーンスタート");
            _unitSetUpUseCase.SetPlayerUnit();
            _unitSetUpUseCase.SetEnemyUnit();
            
            _presenter.SubscribeRound(_saveData.Round);
            _presenter.SubscribeWin(_saveData.Win);
            _presenter.SubscribeLife(_saveData.Life);
            _presenter.SubscribeReRoll(_saveData.ReRoll);
            _presenter.AddStartButtonAction();
        }
    }
}
