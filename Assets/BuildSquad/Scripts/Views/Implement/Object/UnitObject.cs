using BuildSquad.Scripts.Presenters.Data;
using BuildSquad.Scripts.Presenters.Interface;
using UnityEngine;

namespace BuildSquad.Scripts.Views.Implement.Object
{
    [RequireComponent(typeof(UnitAnimationController))]
    public class UnitObject : MonoBehaviour, IUnitObject
    {
        private UnitAnimationController _animationController;

        private void Awake()
        {
            _animationController = GetComponent<UnitAnimationController>();
        }

        public void Initialize(UnitObjectData unit)
        {
            _animationController.SummonNewMonster(unit.Prefab);
        }
    }
}
