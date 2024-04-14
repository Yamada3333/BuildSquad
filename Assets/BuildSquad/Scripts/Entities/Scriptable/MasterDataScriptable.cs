using System.Collections.Generic;
using UnityEngine;

namespace BuildSquad.Scripts.Entities.Scriptable
{
    [CreateAssetMenu(fileName = "MasterData", menuName = "Scriptable/MasterData")]
    public class MasterDataScriptable : ScriptableObject
    {
        public CharacterScriptable initialCharacter0;
        public CharacterScriptable initialCharacter1;
        public CharacterScriptable initialCharacter2;
        
        public List<CharacterScriptable> rowClasses;
        public List<CharacterScriptable> normalClasses;
        public List<CharacterScriptable> highClasses;
    }
}
