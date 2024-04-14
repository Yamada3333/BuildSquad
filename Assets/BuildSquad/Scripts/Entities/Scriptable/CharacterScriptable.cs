using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildSquad.Scripts.Entities.Scriptable
{
    [CreateAssetMenu(fileName = "Character", menuName = "Scriptable/Character")]
    [Serializable]
    public class CharacterScriptable : ScriptableObject
    {
        public GameObject prefab;
        public string characterName;
        public float health = 10;
        public float physicAttack;
        public float physicDefense;
        public float magicAttack;
        public float magicDefense;
        public float speed;
        public int abilityCost = 1;
        public int passiveCost = 1;
        public List<AbilityScriptable> abilities;
        public List<PassiveScriptable> passives;
        
        public bool isFlying;
        // 敵の場合に後衛かどうか true:後衛 false:前衛 Orderbyではfalseが先頭になる
        public bool isBack;
    }
}
