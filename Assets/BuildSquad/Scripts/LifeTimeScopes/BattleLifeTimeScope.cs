using BuildSquad.Scripts.Entities.Model;
using BuildSquad.Scripts.Entities.Scriptable;
using BuildSquad.Scripts.Presenter.Interface;
using BuildSquad.Scripts.Presenters.Data;
using BuildSquad.Scripts.Presenters.Implement;
using BuildSquad.Scripts.Presenters.Interface;
using BuildSquad.Scripts.UseCases.Implement;
using BuildSquad.Scripts.UseCases.Interface.Presenter;
using BuildSquad.Scripts.UseCases.Interface.UseCase;
using BuildSquad.Scripts.View.Implement.Ui;
using BuildSquad.Scripts.Views.Implement.Object;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.LifeTimeScopes
{
    public class BattleLifeTimeScope : LifetimeScope
    {
        [SerializeField] private UnitObject unitObject;
        [SerializeField] private SaveDataScriptable saveData;
        [SerializeField] private MasterDataScriptable masterData;

        [SerializeField] private TextMeshProUGUI roundText;
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private TextMeshProUGUI lifeText;
        [SerializeField] private TextMeshProUGUI reRollText;
        [SerializeField] private SimpleButton startButton;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SquadModel>(Lifetime.Singleton);
            builder.Register<IUnitSetUpPresenter, UnitSetUpPresenter>(Lifetime.Singleton);
            builder.Register<IBattleStartUseCase, BattleStartUseCase>(Lifetime.Singleton);
            builder.Register<UnitSetUpUseCase>(Lifetime.Singleton);
            builder.Register<TurnModel>(Lifetime.Singleton);

            builder.Register<IBattleSceneInitializePresenter, BattleSceneInitializePresenter>(Lifetime.Singleton)
                .WithParameter("round", roundText)
                .WithParameter("win", winText)
                .WithParameter("life", lifeText)
                .WithParameter("reRoll", reRollText)
                .WithParameter<ISimpleButton>(startButton);
            
            builder.RegisterInstance(saveData);
            builder.RegisterInstance(masterData);

            // Viewをスクリプトで動的に生成する場合は、RegisterFactoryで登録する
            builder.RegisterFactory<UnitObjectData, IUnitObject>(Instantiate);

            builder.RegisterEntryPoint<BattleSceneInitializeUseCase>();
        }

        private IUnitObject Instantiate(UnitObjectData data)
        {
            var unitInstance = Instantiate(unitObject, data.Position, Quaternion.identity);
            unitInstance.Initialize(data);
            var scale = unitInstance.transform.localScale;
            scale.x = data.IsPlayer ? 1 : -1;
            unitInstance.transform.localScale = scale;
            return unitInstance;
        }
    }
}
