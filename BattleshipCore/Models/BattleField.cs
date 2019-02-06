using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class BattleField
    {
        public static void ShipPlacement(Ship ship, int xPos, int yPos)
        {
            ship.XPos = xPos;
            ship.YPos = yPos;
            ship.ShipCount--;
        }
    }
}
