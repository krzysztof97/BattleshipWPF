using BattleshipCore.Logic2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    public class User : Player
    {
        HitPlacement hitPlacement = new HitPlacement();

        public User(string name)
        {
            this.Name = name;
            this.Wins = 0;            
        }
    }
}
