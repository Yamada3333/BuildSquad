using System.Collections.Generic;
using System.Linq;
using BuildSquad.Scripts.Entities.Model;
using BuildSquad.Scripts.Entities.Scriptable;
using BuildSquad.Scripts.UseCases.Interface.UseCase;
using R3;
using UnityEngine;
using VContainer;

namespace BuildSquad.Scripts.UseCases.Implement
{
    public class BattleStartUseCase : IBattleStartUseCase
    {
        private readonly SaveDataScriptable _saveData;
        private readonly TurnModel _turnModel;

        private readonly List<BattleUnit> _units = new();

        public readonly Subject<AttackInformation> OnAttack = new();
        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public BattleStartUseCase(SaveDataScriptable saveData, TurnModel turnModel)
        {
            _saveData = saveData;
            _turnModel = turnModel;
        }

        public void BattleStart()
        {
            _turnModel.ClearTurn();
            Debug.Log("バトルスタート");
            CreateBattleUnits();
            Battle();

            _disposable.Dispose();
        }

        private void Battle()
        {
            // 行動したユニットがいる間はループ
            while (Turn())
            {
                // ターン終了処理
                _units.ToList().ForEach(unit => unit.TurnEnd());
                _turnModel.NextTurn();
                Debug.Log("ターン終了");
                break;
            }
        }

        private bool Turn()
        {
            var count = 0;
            while (_units.Any(unit => unit.IsAction()))
            {
                var battleUnit = GetActionUnit();
                var attackInformation = GetAttackInformation(battleUnit);
                if (attackInformation != null) OnAttack.OnNext(attackInformation);
                battleUnit.Action();
                count++;
                Debug.Log(battleUnit);
            }
            
            return count > 0;
        }

        private BattleUnit GetActionUnit()
        {
            return _units
                .Where(unit => unit.IsAction())
                .OrderByDescending(unit => unit.GetSpeed())
                .First();
        }

        private AttackInformation GetAttackInformation(BattleUnit battleUnit)
        {
            var abilities = battleUnit.GetAbilities();
            foreach (var ability in abilities)
            {
                if (ability.cost > battleUnit.AbilityCost) continue;
                var positionsList = ability.GetPointsList(battleUnit.GetPosition());
                var targetUnits = GetTargetUnits(positionsList);

                if (targetUnits == null) continue;
                battleUnit.AbilityCost -= ability.cost;
                return new AttackInformation(battleUnit, targetUnits, ability);
            }

            return null;
        }

        private List<BattleUnit> GetTargetUnits(IEnumerable<List<(int row, int col)>> positionsList)
        {
            var targetUnits = new List<BattleUnit>();
            foreach (var positions in positionsList)
            {
                foreach (var position in positions)
                {
                    // positionsの位置にいるユニットを取得
                    targetUnits.AddRange(_units.Where(unit => unit.GetPosition() == position));
                }

                if (targetUnits.Count > 0) return targetUnits;
            }

            return null;
        }

        private void CreateBattleUnits()
        {
            var squadModel = _saveData.SquadModel;
            foreach (var unit in squadModel.Units)
            {
                var battleUnit = new BattleUnit(unit);
                battleUnit.OnAttack.Subscribe(_ => unit.OnAttack.OnNext(Unit.Default)).AddTo(_disposable);
                battleUnit.OnDead.Subscribe(_ => unit.OnDead.OnNext(Unit.Default)).AddTo(_disposable);
                _units.Add(battleUnit);
            }
        }
    }
}
