using BattleshipCore.Models;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2
{
    public class HitPlacement
    {

        public bool Placemen(Armada armada, ref HitMissle missle, HitList hitList)
        {
            bool hit = true;
            foreach (var bomb in hitList.ListOfHit)
            {
                if (!(bomb.XPos == missle.XPos) && !(bomb.YPos == missle.YPos))
                {
                    hit = true;
                    foreach (var ship in armada.Army)
                    {
                        switch (ship.Orientation)
                        {
                            case (OrientationEnum.Horizontal):
                                if (ship.YPos != missle.YPos)
                                {
                                    missle.IsHit = HitValueEnum.Missed;
                                }
                                for (int i = ship.XPos; i < ship.XPos + ship.Size; i++)
                                {
                                    if (i == missle.XPos)
                                    {
                                        missle.IsHit = HitValueEnum.Hitted;
                                    }
                                    else
                                        missle.IsHit = HitValueEnum.Missed;
                                }
                                    break;
                            case (OrientationEnum.Vertical):
                                if (ship.XPos != missle.XPos)
                                {
                                    missle.IsHit = HitValueEnum.Missed;
                                }
                                for (int i = ship.YPos; i < ship.YPos + ship.Size; i++)
                                {
                                    if (i == missle.YPos)
                                    {
                                        missle.IsHit = HitValueEnum.Hitted;
                                    }
                                    else
                                        missle.IsHit = HitValueEnum.Missed;
                                }
                                    break;
                        }

                    }
                    hitList.ListOfHit.Add(missle);
                }
                else
                    hit = false;
            }
            return hit;
        }

        //public void Horizontal(Ship ship, HitMissle missle)
        //{
        //    if (ship.YPos != missle.YPos)
        //    {
        //        missle.IsHit = HitValueEnum.Missed;
        //    }
        //    for (int i = ship.XPos; i < ship.XPos + ship.Size; i++)
        //    {
        //        if (i == missle.XPos)
        //        {
        //            missle.IsHit = HitValueEnum.Hitted;
        //        }
        //        else
        //            missle.IsHit = HitValueEnum.Missed;
        //    }
        //}
        //public void Vertical(Ship ship, HitMissle missle)
        //{
        //    if (ship.XPos != missle.XPos)
        //    {
        //        missle.IsHit = HitValueEnum.Missed;
        //    }
        //    for (int i = ship.YPos; i < ship.YPos + ship.Size; i++)
        //    {
        //        if (i == missle.YPos)
        //        {
        //            missle.IsHit = HitValueEnum.Hitted;
        //        }
        //        else
        //            missle.IsHit = HitValueEnum.Missed;
        //    }
        
    }
}
