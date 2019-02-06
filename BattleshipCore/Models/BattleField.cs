using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class BattleField
    {
        private bool isFree = true;
        private readonly int width = 10;
        private readonly int height = 10;
        private Ship[,] arrayField;

        public bool IsFree { get => isFree; set => isFree = value; }

        public int Width => width;

        public int Height => height;

        public Ship[,] ArrayField { get => arrayField; set => arrayField = value; }

        public BattleField()
        {
            ArrayField = new Ship[Width, Height];
        }
    }
}