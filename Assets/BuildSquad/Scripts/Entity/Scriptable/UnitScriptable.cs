using System;
using BuildSquad.Scripts.Entity.Scriptable.Weapon;
using UnityEngine;

namespace BuildSquad.Scripts.Entity.Scriptable
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Scriptable/Unit")]
    [Serializable]
    public class UnitScriptable : ScriptableObject
    {
        public ClassScriptable classScriptable;
        public WeaponScriptable weapon;
        public ShieldScriptable shield;
        public AccessoryScriptable accessory;
    }
}
