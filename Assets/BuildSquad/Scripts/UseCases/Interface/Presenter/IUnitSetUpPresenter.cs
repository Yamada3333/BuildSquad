using BuildSquad.Scripts.UseCases.Data;

namespace BuildSquad.Scripts.UseCases.Interface.Presenter
{
    public interface IUnitSetUpPresenter
    {
        void InstantiateUnit(UnitData unitObjectData);
    }
}
