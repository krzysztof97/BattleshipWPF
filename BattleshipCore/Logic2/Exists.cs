using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    /// <summary>
    /// Logic class.
    /// </summary>
    static class Exists
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="XPos">horizontal point</param>
        /// <param name="YPos">vertical point</param>
        /// <param name="ship"> object with List of ship</param>
        /// <returns>bool value true if ship exsist in this point</returns>
        public static bool Ship(int XPos, int YPos, Ship ship)
        {
            if(ship.Orientation == OrientationEnum.Horizontal)
            {
                return CheckHorizontal(XPos, YPos, ship);
            }

            if (ship.Orientation == OrientationEnum.Vertical)
            {
                return CheckVertical(XPos, YPos, ship);
            }

            return false;
        }
        /// <summary>
        /// ship.Orentation =Horizontal
        /// </summary>
        /// <param name="XPos">horizontal point</param>
        /// <param name="YPos">vertical point</param>
        /// <param name="ship"> object with List of ship</param>
        /// <returns>bool value</returns>
        private static bool CheckHorizontal(int XPos, int YPos, Ship ship)
        {
            if (YPos != ship.YPos)
            {
                return false;
            }

            for (int i = ship.XPos; i < ship.XPos + ship.Size; i++)
            {
                if(i == XPos)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// ship.Orentation = Vertical
        /// </summary>
        /// <param name="XPos">horizontal point</param>
        /// <param name="YPos">vertical point</param>
        /// <param name="ship"> object with List of ship</param>
        /// <returns>bool value</returns>
        private static bool CheckVertical(int XPos, int YPos, Ship ship)
        {
            if (XPos != ship.XPos)
            {
                return false;
            }

            for (int i = ship.YPos; i < ship.YPos + ship.Size; i++)
            {
                if (i == YPos)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
