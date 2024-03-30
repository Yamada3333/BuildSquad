using System;
using BuildSquad.Scripts.Entity.Enum;
using UnityEngine;

namespace BuildSquad.Scripts.Entity.Scriptable.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable/Equipment/Weapon")]
    [Serializable]
    public class WeaponScriptable : EquipmentScriptable
    {
        public WeaponType weaponType;
    }
}
