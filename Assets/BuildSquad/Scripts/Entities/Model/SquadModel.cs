using System;
using System.Collections.Generic;
using System.Linq;
using BuildSquad.Scripts.Entities.Scriptable;

namespace BuildSquad.Scripts.Entities.Model
{
    public class SquadModel
    {
        public readonly List<UnitModel> Units = new();

        private static readonly List<(int, int)> PositionList = new()
        {
            (0, 0),
            (0, 1),
            (1, 0),
            (1, 1),
            (0, 2),
            (1, 2),
            (2, 0),
            (2, 1),
            (2, 2),
            (0, 3),
            (1, 3),
            (2, 3),
            (3, 0),
            (3, 1),
            (3, 2),
            (3, 3),
        };
        
        public SquadModel(MasterDataScriptable masterData)
        {
            Units.Add(new UnitModel(true, (1, 0), masterData.initialCharacter0));
            Units.Add(new UnitModel(true, (0, 1), masterData.initialCharacter1));
            Units.Add(new UnitModel(true, (2, 1), masterData.initialCharacter2));
        }

        public void SetUpEnemy(int round, int difficulty, MasterDataScriptable masterData)
        {
            Units.RemoveAll(unit => !unit.IsPlayer);
            var characterStack = GetCharacterStack(round, difficulty, masterData);

            var randomPositionList = GetRandomPositionList(round);
            foreach (var position in randomPositionList)
            {
                var classScriptable = characterStack.Pop();
                var unitModel = new UnitModel(false, position, classScriptable);
                Units.Add(unitModel);
            }
        }

        // ユニットの配置をランダムに決定
        private static List<(int x, int y)> GetRandomPositionList(int round)
        {
            var count = round + 2;
            return count switch
            {
                // 0~4: 2 * 2
                <= 4 => PositionList.Take(4).OrderBy(_ => Guid.NewGuid()).Take(count).ToList(),
                // 5~9: 3 * 3
                <= 9 => PositionList.Take(9).OrderBy(_ => Guid.NewGuid()).Take(count).ToList(),
                // 10~16: 4 * 4
                _ => PositionList.OrderBy(_ => Guid.NewGuid()).Take(count).ToList()
            };
        }

        private static Stack<CharacterScriptable> GetCharacterStack(int round, int difficulty, MasterDataScriptable masterData)
        {
            var list = new List<CharacterScriptable>();
            var level = round + difficulty;

            const int maxCharacter = 10;
            var count = Math.Min(maxCharacter, round + 2);
            var highCount = level % maxCharacter;

            switch (level)
            {
                case < maxCharacter * 2:
                    list.AddRange(masterData.rowClasses.OrderBy(_ => Guid.NewGuid()).Take(count - highCount));
                    list.AddRange(masterData.normalClasses.OrderBy(_ => Guid.NewGuid()).Take(highCount));
                    break;
                case < maxCharacter * 3:
                    list.AddRange(masterData.normalClasses.OrderBy(_ => Guid.NewGuid()).Take(count - highCount));
                    list.AddRange(masterData.highClasses.OrderBy(_ => Guid.NewGuid()).Take(highCount));
                    break;
                default:
                    list.AddRange(masterData.highClasses.OrderBy(_ => Guid.NewGuid()).Take(maxCharacter));
                    break;
            }

            return new Stack<CharacterScriptable>(list.OrderBy(_ => Guid.NewGuid()));
        }
    }
}
