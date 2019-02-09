using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class Free : IComparable
    {
        public static bool IsFree(Ship aship, Ship ship)
        {
            bool isFree = true;


            switch (aship.Orientation)
            {
                case OrientationEnum.Horizontal:
                    for (int i = aship.XPos-1; i < (aship.XPos + aship.Size); i++)
                    {
                        for (int j = ship.XPos-1; j < (ship.XPos + ship.Size); j++)
                        {
                            if (i == j)
                            {
                                isFree = false;
                            }
                            else
                                isFree = true;
                        }
                    }
                    break;
                case OrientationEnum.Vertical:
                    for (int i = aship.YPos-1; i < (aship.YPos + aship.Size); i++)
                    {
                        for (int j = ship.YPos-1; j < (ship.YPos + ship.Size); j++)
                        {
                            if (i == j)
                            {
                                isFree = false;
                            }
                            else
                                isFree = true;
                        }
                    }
                    break;
            }
            switch (ship.Orientation)
            {
                case OrientationEnum.Horizontal:
                    for (int i = aship.XPos-1; i < (aship.XPos + aship.Size); i++)
                    {
                        for (int j = ship.XPos-1; j < (ship.XPos + ship.Size); j++)
                        {
                            if (i == j)
                            {
                                isFree = false;
                                break;
                            }
                            else
                                isFree = true;
                        }
                    }
                    break;
                case OrientationEnum.Vertical:
                    for (int i = aship.YPos-1; i < (aship.YPos + aship.Size); i++)
                    {
                        for (int j = ship.YPos-1; j < (ship.YPos + ship.Size); j++)
                        {
                            if (i == j)
                            {
                                isFree = false;
                                break;
                            }
                            else
                                isFree = true;
                        }
                    }
                    break;
            }
            //for (int i = min; i < max; i++)
            //{
            //    if (i == value)
            //    {
            //        isFree = false;
            //    }
            //    else
            //        isFree = true;
            //}
            return isFree;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
