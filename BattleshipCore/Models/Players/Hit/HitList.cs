using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players.Hit
{
    class HitList
    {
        private List<Hit> listOfHit = new List<Hit>();

        public List<Hit> ListOfHit { get => listOfHit; set => listOfHit = value; }
    }
}
