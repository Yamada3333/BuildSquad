using System.Collections.Generic;
using BuildSquad.Scripts.Entities.Scriptable;
using R3;

namespace BuildSquad.Scripts.Entities.Model
{
    public class BattleUnit
    {
        
        private bool _isAction = true;
        private readonly ReactiveProperty<float> _health = new();
        private readonly UnitModel _unitModel;

        public readonly Subject<Unit> OnAttack = new();
        public readonly Subject<Unit> OnDead = new();
        
        public int AbilityCost;
        public int PassiveCost;

        public BattleUnit(UnitModel unitModel)
        {
            _unitModel = unitModel;
            _health.Value = unitModel.Character.health;
            AbilityCost = unitModel.Character.abilityCost;
            PassiveCost = unitModel.Character.passiveCost;
        }
        
        public bool IsAction()
        {
            return _isAction;//後で死亡判定を追加
        }

        public void Action()
        {
            OnAttack.OnNext(Unit.Default);
            _isAction = false;
        }
        
        public void TurnEnd()
        {
            _isAction = true;
        }
        
        public float GetSpeed()
        {
            return _unitModel.Character.speed;
        }

        public IEnumerable<AbilityScriptable> GetAbilities()
        {
            return _unitModel.Character.abilities;
        }

        public (int, int ) GetPosition()
        {
            return _unitModel.Position;
        }
    }
}
