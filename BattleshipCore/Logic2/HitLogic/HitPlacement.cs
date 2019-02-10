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

        public bool Placemen(Armada armada, HitMissle missle, HitList hitList)
        {
            bool hit = false;
            foreach (var bomb in hitList.ListOfHit)
            {
                if (!(bomb.XPos == missle.XPos) || !(bomb.YPos == missle.YPos))
                {
                    foreach (var aship in armada.Army)
                    {
                        switch (aship.Orientation)
                        {
                            case OrientationEnum.Horizontal:
                                if (aship.YPos != missle.YPos)
                                {
                                    hit = true;
                                    break;
                                    missle.IsHit = HitValueEnum.Missed;

                                }
                                for (int i = aship.XPos; i < aship.XPos + aship.Size; i++)
                                {
                                    if (i == missle.XPos)
                                    {
                                        hit = true;
                                        missle.IsHit = HitValueEnum.Hitted;
                                    }
                                    else
                                        missle.IsHit = HitValueEnum.Missed;
                                }
                                break;
                            case OrientationEnum.Vertical:
                                if (aship.XPos != missle.XPos)
                                {
                                    hit = true;
                                    missle.IsHit = HitValueEnum.Missed;
                                    break;
                                }
                                for (int i = aship.YPos; i < aship.YPos + aship.Size; i++)
                                {
                                    if (i == missle.YPos)
                                    {
                                        hit = true;
                                        missle.IsHit = HitValueEnum.Missed;
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
                    hit=false;
            }
            return hit;
        }
    }
}
