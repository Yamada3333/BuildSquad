using System.Linq;

namespace BuildSquad.Scripts.Entity.Scriptable
{
    public class GroupScriptable
    {
        public readonly UnitScriptable[,] units = new UnitScriptable[2, 3];

        /// <summary>
        /// unitsの中にunitが３つかチェック
        /// </summary>
        /// <returns> bool </returns>
        public bool CheckUnit()
        {
            return units
                .Cast<UnitScriptable>()
                .Count(unit => unit != null)
                .Equals(3);
        }
    }
}
