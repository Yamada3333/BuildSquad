using System;
using UnityEngine;

namespace BuildSquad.Scripts.Entity.Scriptable
{
    public class AbilityScriptable : ScriptableObject
    {
        public string abilityName;
        public int cost;
        public float physicPower;
        public float magicPower;
        public bool isRange;
    }
}
