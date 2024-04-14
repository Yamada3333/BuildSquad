using BuildSquad.Scripts.Entities.Model;
using R3;
using UnityEngine;

namespace BuildSquad.Scripts.Entities.Scriptable
{
    [CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable/SaveData")]
    public class SaveDataScriptable : ScriptableObject
    {
        public readonly ReactiveProperty<int> Round = new (1);
        public readonly ReactiveProperty<int> Difficulty = new (0);
        public readonly ReactiveProperty<int> Win = new (0);
        public readonly ReactiveProperty<int> Life = new(3);
        public readonly ReactiveProperty<int> ReRoll = new(3);
        
        public SquadModel SquadModel;
    }
}
