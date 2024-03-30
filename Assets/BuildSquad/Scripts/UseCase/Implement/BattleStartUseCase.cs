using BuildSquad.Scripts.Entity.Scriptable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BuildSquad.Scripts.UseCase.Implement
{
    public class BattleStartUseCase : IStartable
    {
        private readonly SquadScriptable _squadScriptable;
        
        [Inject]
        public BattleStartUseCase(SquadScriptable squadScriptable)
        {
            _squadScriptable = squadScriptable;
            
            if (!_squadScriptable.CheckGroup())
            {
                Debug.LogError("ユニットが３つ揃っていません");
            }
        }

        public void Start()
        {
            Debug.Log("バトルスタート");
            
            
        }
    }
}
