using System.Linq;
using BuildSquad.Scripts.Entities.Model;
using BuildSquad.Scripts.Entities.Scriptable;
using BuildSquad.Scripts.UseCases.Data;
using BuildSquad.Scripts.UseCases.Interface.Presenter;
using VContainer;

namespace BuildSquad.Scripts.UseCases.Implement
{
    // Battleシーンに遷移時にユニットのセットアップを行う
    public class UnitSetUpUseCase
    {
        private readonly SaveDataScriptable _saveData;
        private readonly SquadModel _squadModel;
        private readonly MasterDataScriptable _masterData;
        private readonly IUnitSetUpPresenter _unitSetUpPresenter;
        
        [Inject]
        public UnitSetUpUseCase(SaveDataScriptable saveData, SquadModel squadModel, MasterDataScriptable masterData, IUnitSetUpPresenter unitSetUpPresenter)
        {
            _saveData = saveData;
            _squadModel = squadModel;
            _masterData = masterData;
            _unitSetUpPresenter = unitSetUpPresenter;
        }
        
        public void SetPlayerUnit()
        {
            _saveData.SquadModel = _squadModel;
            Instantiate(true);
        }
        
        public void SetEnemyUnit()
        {
            var round = _saveData.Round.Value;
            var difficulty = _saveData.Difficulty.Value;
            _squadModel.SetUpEnemy(round, difficulty, _masterData);
            Instantiate(false);
        }

        private void Instantiate(bool isPlayer)
        {
            var units = _squadModel.Units
                .Where(unit => unit.IsPlayer == isPlayer)
                .Select(unit => new UnitData(isPlayer, unit.Position, unit.Character.prefab));

            foreach (var unitData in units)
            {
                _unitSetUpPresenter.InstantiateUnit(unitData);
            }
        }
    }
}
