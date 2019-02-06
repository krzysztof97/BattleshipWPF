using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    class User : Player
    {
        public User(string name)
        {
            this.Name = name;
            this.Wins = 0;
        }
    }
}
