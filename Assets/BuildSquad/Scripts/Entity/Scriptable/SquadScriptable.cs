using System.Linq;

namespace BuildSquad.Scripts.Entity.Scriptable
{
    public class SquadScriptable
    {
        public GroupScriptable[,] playerGroups = new GroupScriptable[2, 3];
        public GroupScriptable[,] enemyGroups = new GroupScriptable[2, 3];
        
        public bool CheckGroup()
        {
            return playerGroups
                       .Cast<GroupScriptable>()
                       .Where(group => group != null)
                       .Count(group => group.CheckUnit())
                       .Equals(3)
                   &&
                   enemyGroups
                       .Cast<GroupScriptable>()
                       .Where(group => group != null)
                       .Count(group => group.CheckUnit())
                       .Equals(3);
        }
    }
}
