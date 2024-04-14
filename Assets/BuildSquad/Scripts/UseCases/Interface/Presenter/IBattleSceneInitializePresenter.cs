using R3;

namespace BuildSquad.Scripts.UseCases.Interface.Presenter
{
    public interface IBattleSceneInitializePresenter
    {
        void SubscribeRound(ReactiveProperty<int> round);
        void SubscribeWin(ReactiveProperty<int> win);
        void SubscribeLife(ReactiveProperty<int> life);
        void SubscribeReRoll(ReactiveProperty<int> reRoll);
        void AddStartButtonAction();
    }
}
