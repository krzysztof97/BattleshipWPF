using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    /// <summary>
    /// Basic class for player and AI.
    /// </summary>
    public class Player
    {

    /// <param name="name">describe Name</param>
    /// <param name="wins">describe nuber of win(not implemented yet)</param>
    /// <param name="trun">bool walue. Use to give us informaction whose next turn</param>
        private string name;
        private int wins;
        private bool turn;

        public string Name { get => name; set => name = value; }
        public int Wins { get => wins; set => wins = value; }
        public bool Turn { get => turn; set => turn = value; }
    }
}
