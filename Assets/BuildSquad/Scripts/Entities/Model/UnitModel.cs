using BuildSquad.Scripts.Entities.Scriptable;
using R3;

namespace BuildSquad.Scripts.Entities.Model
{
    public class UnitModel
    {
        public readonly bool IsPlayer;
        public (int row, int col) Position;
        public readonly CharacterScriptable Character;
        public readonly Subject<Unit> OnAttack = new();
        public readonly Subject<Unit> OnDead = new();
        
        public UnitModel(bool isPlayer, (int row, int col) position, CharacterScriptable character)
        {
            IsPlayer = isPlayer;
            Position = position;
            Character = character;
        }
    }
}
