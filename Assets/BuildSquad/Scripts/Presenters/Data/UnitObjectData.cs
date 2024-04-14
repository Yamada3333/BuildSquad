using UnityEngine;

namespace BuildSquad.Scripts.Presenters.Data
{
    public class UnitObjectData
    {
        public readonly bool IsPlayer;
        public readonly Vector2 Position;
        public readonly GameObject Prefab;

        public UnitObjectData(bool isPlayer, Vector2 position, GameObject prefab)
        {
            IsPlayer = isPlayer;
            Position = position;
            Prefab = prefab;
        }
    }
}
