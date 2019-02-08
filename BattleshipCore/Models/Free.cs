using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class Free
    {
        public static bool IsFreeShip(Ship ship, int valueX, int valueY)
        {
            int min = 0;
            int max = ship.Size;
            int value=0;

            bool isFree = true;

            switch (ship.Orientation)
            {
                case OrientationEnum.Horizontal:
                    min = ship.XPos;
                    value = valueX;
                    break;
                case OrientationEnum.Vertical:
                    min = ship.YPos;
                    value = valueY;
                    break;
            }


            for (int i = min; i < max; i++)
            {
                if (i == value)
                {
                    isFree = false;
                }
            }
            return isFree;
        }      
    }
}
