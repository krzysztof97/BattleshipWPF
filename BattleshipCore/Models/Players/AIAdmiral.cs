using BattleshipCore.Logic2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipCore.Models.Players;


namespace BattleshipCore.Models.Players
{
    public class AIAdmiral : Player
    {
        
        HitPlacement hitPlacement = new HitPlacement();
         

        internal HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }

        public AIAdmiral()
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
        }

    }
}
