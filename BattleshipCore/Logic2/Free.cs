using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    /// <summary>
    /// Logic class. Use to state whether localization is free
    /// </summary>
    class Free
    {
        /// <summary>
        /// bool function.
        /// </summary>
        /// <param name="ship1">first ship</param>
        /// <param name="ship2">second ship</param>
        /// <returns>bool value. give us information is this ship can be Deploy</returns>
        public static bool IsFree(Ship ship1, Ship ship2)
        {
            if(ship1.Orientation == OrientationEnum.Horizontal && ship2.Orientation == OrientationEnum.Horizontal)
            {
                return CheckBothHorizontal(ship1, ship2);
            }

            if (ship1.Orientation == OrientationEnum.Vertical && ship2.Orientation == OrientationEnum.Vertical)
            {
                return CheckBothVertical(ship1, ship2);
            }

            if (ship1.Orientation == OrientationEnum.Horizontal && ship2.Orientation == OrientationEnum.Vertical)
            {
                return CheckHorizontalAndVertical(ship1, ship2);
            }

            if (ship1.Orientation == OrientationEnum.Vertical && ship2.Orientation == OrientationEnum.Horizontal)
            {
                return CheckHorizontalAndVertical(ship2, ship1);
            }

            return false;
        }
        /// <summary>
        /// check when ships has similar value ship.Orientation=Horizontal.
        /// </summary>
        /// <param name="ship1">first ship</param>
        /// <param name="ship2">second ship</param>
        /// <returns>bool value</returns>
        private static bool CheckBothHorizontal(Ship ship1, Ship ship2)
        {
            if (ship1.YPos != ship2.YPos)
            {
                return true;
            }

            for (int i = ship1.XPos; i < ship1.XPos + ship1.Size; i++)
            {
                for (int j = ship2.XPos; j < ship2.XPos + ship2.Size; j++)
                {
                    if(i == j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// check when ships has similar value ship.Orientation=vertical.
        /// </summary>
        /// <param name="ship1">first ship</param>
        /// <param name="ship2">second ship</param>
        /// <returns>bool value</returns>
        private static bool CheckBothVertical(Ship ship1, Ship ship2)
        {
            if (ship1.XPos != ship2.XPos)
            {
                return true;
            }

            for (int i = ship1.YPos; i < ship1.YPos + ship1.Size; i++)
            {
                for (int j = ship2.YPos; j < ship2.YPos + ship2.Size; j++)
                {
                    if (i == j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// use to check diffrent Orientation value
        /// </summary>
        /// <param name="shipH">ship.Orientation=Horizontal</param>
        /// <param name="shipV">ship.Orientation=Vertical</param>
        /// <returns>bool value</returns>
        private static bool CheckHorizontalAndVertical(Ship shipH, Ship shipV)
        {
            for (int i = shipH.XPos; i < shipH.XPos + shipH.Size; i++)
            {
                for (int j = shipV.YPos; j < shipV.YPos + shipV.Size; j++)
                {
                    if (i == shipV.XPos && j == shipH.YPos)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
