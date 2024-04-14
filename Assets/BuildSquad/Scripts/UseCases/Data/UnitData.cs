using UnityEngine;

namespace BuildSquad.Scripts.UseCases.Data
{
    public class UnitData
    {
        public readonly bool IsPlayer;
        public readonly (int x, int y) Position;
        public readonly GameObject Prefab;
        
        public UnitData(bool isPlayer, (int x, int y) position, GameObject prefab)
        {
            IsPlayer = isPlayer;
            Position = position;
            Prefab = prefab;
        }
    }
}
