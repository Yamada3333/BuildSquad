using BuildSquad.Scripts.UseCases.Interface.UseCase;
using VContainer;

namespace BuildSquad.Scripts.Presenters.Implement
{
    public class BattleStartPresenter
    {
        private IBattleStartUseCase _battleStartUseCase;
        
        [Inject]
        public BattleStartPresenter(IBattleStartUseCase battleStartUseCase)
        {
            _battleStartUseCase = battleStartUseCase;
        }
        
        
    }
}
