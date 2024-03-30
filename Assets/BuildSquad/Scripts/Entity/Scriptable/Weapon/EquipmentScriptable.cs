using UnityEngine;

namespace BuildSquad.Scripts.Entity.Scriptable.Weapon
{
    public class EquipmentScriptable : ScriptableObject
    {
        public string equipmentName;
        public float physicAttack;
        public float physicDefense;
        public float magicAttack;
        public float magicDefense;
        public float speed;
        public int abilityCost;
        public int passiveCost;
        public AbilityScriptable ability;
        public PassiveScriptable passive;
    }
}
