using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class Player
    {
        private string name;
        private int wins;

        public string Name { get => name; set => name = value; }
        public int Wins { get => wins; set => wins = value; }


    }
}
