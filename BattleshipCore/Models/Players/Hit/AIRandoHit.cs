using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    class AIRandoHit
    {
        public int AIRandoHi(int gridLow, int gridMax)
        {
            int valuve;
            Random rand = new Random();

            valuve = rand.Next(gridLow, gridMax);

            return valuve;

        }
    }
}
