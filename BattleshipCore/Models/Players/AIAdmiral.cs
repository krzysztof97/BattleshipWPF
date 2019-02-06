using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    class AIAdmiral : Player
    {
        public AIAdmiral()
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
        }

    }
}
