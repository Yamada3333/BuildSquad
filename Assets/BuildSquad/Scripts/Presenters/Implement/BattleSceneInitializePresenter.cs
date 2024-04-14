using BuildSquad.Scripts.Presenter.Interface;
using BuildSquad.Scripts.UseCases.Interface.Presenter;
using BuildSquad.Scripts.UseCases.Interface.UseCase;
using R3;
using TMPro;

namespace BuildSquad.Scripts.Presenters.Implement
{
    public class BattleSceneInitializePresenter : IBattleSceneInitializePresenter
    {
        private readonly TextMeshProUGUI _roundText;
        private readonly TextMeshProUGUI _winText;
        private readonly TextMeshProUGUI _lifeText;
        private readonly TextMeshProUGUI _reRollText;
        private readonly ISimpleButton _startButton;
        private readonly IBattleStartUseCase _battleStartUseCase;

        public BattleSceneInitializePresenter(TextMeshProUGUI round, TextMeshProUGUI win, TextMeshProUGUI life,
            TextMeshProUGUI reRoll, ISimpleButton startButton, IBattleStartUseCase battleStartUseCase)
        {
            _roundText = round;
            _winText = win;
            _lifeText = life;
            _reRollText = reRoll;
            _startButton = startButton;
            _battleStartUseCase = battleStartUseCase;
        }

        public void SubscribeRound(ReactiveProperty<int> round)
        {
            round.Subscribe(score => _roundText.text = score.ToString());
        }
        
        public void SubscribeWin(ReactiveProperty<int> win)
        {
            win.Subscribe(score => _winText.text = score.ToString());
        }
        
        public void SubscribeLife(ReactiveProperty<int> life)
        {
            life.Subscribe(score => _lifeText.text = score.ToString());
        }
        
        public void SubscribeReRoll(ReactiveProperty<int> reRoll)
        {
            reRoll.Subscribe(score => _reRollText.text = score.ToString());
        }

        public void AddStartButtonAction()
        {
            _startButton.OnClick.Subscribe(_ => _battleStartUseCase.BattleStart());
        }
    }
}
