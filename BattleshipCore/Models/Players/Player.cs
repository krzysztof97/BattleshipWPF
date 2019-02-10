using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    public class Player
    {
        private string name;
        private int wins;
        private bool turn;

        public string Name { get => name; set => name = value; }
        public int Wins { get => wins; set => wins = value; }
        public bool Turn { get => turn; set => turn = value; }
    }
}
