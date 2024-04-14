using System;
using System.Collections.Generic;
using System.Linq;
using BuildSquad.Scripts.Entities.Enum;
using UnityEngine;

namespace BuildSquad.Scripts.Entities.Scriptable
{
    public class AbilityScriptable : ScriptableObject
    {
        public string abilityName;
        public int cost = 1;
        public float physicPower;
        public float magicPower;
        public bool isRange;
        
        // 攻撃対象用
        public AbilityTargetType targetType;
        public bool isFly = true; // 飛行ユニットに対して有効
        
        public IEnumerable<List<(int row, int col)>> GetPointsList((int row, int col) position)
        {
            var positionsList = new List<List<(int row, int col)>>();
            var cols = isRange ? Enumerable.Range(0, 4).Reverse().ToList() : Enumerable.Range(0, 4).ToList();
            var rows = Enumerable.Range(0, 4).OrderBy(row => row - position.row).ToList();
            
            switch (targetType)
            {
                case AbilityTargetType.Single:
                    // colsとrowsの組み合わせを全て列挙
                    positionsList.AddRange(from col in cols from row in rows select new List<(int row, int col)> {(row, col)});
                    break;
                case AbilityTargetType.Row:
                    // rowsの組み合わせを全て列挙
                    positionsList.AddRange(rows.Select(row => cols.Select(col => (row, col)).ToList()));
                    break;
                case AbilityTargetType.Vertical:
                    // colsの組み合わせを全て列挙
                    positionsList.AddRange(cols.Select(col => rows.Select(row => (row, col)).ToList()));
                    break;
                case AbilityTargetType.All:
                    // 全ての組み合わせを列挙
                    positionsList.Add(rows.SelectMany(row => cols.Select(col => (row, col))).ToList());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return positionsList;
        }
    }
}
