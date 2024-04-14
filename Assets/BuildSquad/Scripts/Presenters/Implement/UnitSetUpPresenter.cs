using System;
using BuildSquad.Scripts.Presenters.Data;
using BuildSquad.Scripts.Presenters.Interface;
using BuildSquad.Scripts.UseCases.Data;
using BuildSquad.Scripts.UseCases.Interface.Presenter;
using UnityEngine;
using VContainer;

namespace BuildSquad.Scripts.Presenters.Implement
{
    public class UnitSetUpPresenter : IUnitSetUpPresenter
    {
        private readonly Func<UnitObjectData, IUnitObject> _unit;
        private const float UnitDistance = 1.5f;

        [Inject]
        public UnitSetUpPresenter(Func<UnitObjectData, IUnitObject> unit)
        {
            _unit = unit;
        }

        public void InstantiateUnit(UnitData unitData)
        {
            var isPlayer = unitData.IsPlayer;
            var position = GetPositionFromType(isPlayer, unitData.Position);
            var prefab = unitData.Prefab;
            var unitObjectData = new UnitObjectData(isPlayer, position, prefab);
            _unit.Invoke(unitObjectData);
        }

        private static Vector2 GetPositionFromType(bool isPlayer, (int row, int col) position)
        {
            var row = position.row * UnitDistance - UnitDistance * 1.5f;
            var col = position.col * UnitDistance + UnitDistance;
            const float z = 0f;
            var localPosition = new Vector3(col, row, z);

            if (isPlayer) localPosition.x *= -1;
            
            return localPosition;
        }
    }
}
