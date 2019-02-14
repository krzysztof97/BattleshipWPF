using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    static class Exists
    {
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
