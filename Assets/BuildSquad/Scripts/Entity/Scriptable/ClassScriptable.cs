using System;
using BuildSquad.Scripts.Entity.Enum;
using UnityEngine;

namespace BuildSquad.Scripts.Entity.Scriptable
{
    [CreateAssetMenu(fileName = "Class", menuName = "Scriptable/Class")]
    [Serializable]
    public class ClassScriptable : ScriptableObject
    {
        public string className;
        public float health;
        public float physicAttack;
        public float physicDefense;
        public float magicAttack;
        public float magicDefense;
        public float speed;
        
        public WeaponType weaponType;
        public bool isFlying;
        // 敵の場合に前衛かどうか
        public bool isFront;
    }
}
