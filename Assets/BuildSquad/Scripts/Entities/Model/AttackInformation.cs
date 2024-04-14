using System.Collections.Generic;
using BuildSquad.Scripts.Entities.Scriptable;

namespace BuildSquad.Scripts.Entities.Model
{
    public class AttackInformation
    {
        public BattleUnit Attacker;
        public List<BattleUnit> Targets;
        public AbilityScriptable Ability;
        
        public AttackInformation(BattleUnit attacker, List<BattleUnit> targets, AbilityScriptable ability)
        {
            Attacker = attacker;
            Targets = targets;
            Ability = ability;
        }
    }
}
