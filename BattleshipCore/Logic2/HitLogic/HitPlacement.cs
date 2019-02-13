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
        private HitMissle missle;
        private HitValueEnum isHit;

       
        public HitMissle Missle { get => missle; set => missle = value; }
        public HitValueEnum IsHit { get => isHit; set => isHit = value; }

        public bool Placemen(Armada armada, HitList hitList, int xPos, int yPos)
        {
            Missle = new HitMissle(xPos, yPos);

            bool hit = true;
            foreach (var bomb in hitList.ListOfHit)
            {
                if (!(bomb.XPos == Missle.XPos) && !(bomb.YPos == Missle.YPos))
                {
                    hit = true;
                    foreach (var ship in armada.Army)
                    {
                        switch (ship.Orientation)
                        {
                            case (OrientationEnum.Horizontal):
                                if (ship.YPos != Missle.YPos)
                                {
                                    Missle.IsHit = HitValueEnum.Missed;
                                }
                                for (int i = ship.XPos; i < ship.XPos + ship.Size; i++)
                                {
                                    if (i == Missle.XPos)
                                    {
                                        Missle.IsHit = HitValueEnum.Hitted;
                                    }
                                    else
                                    {
                                        Missle.IsHit = HitValueEnum.Missed;
                                    }

                                }
                                break;
                            case (OrientationEnum.Vertical):
                                if (ship.XPos != Missle.XPos)
                                {
                                    Missle.IsHit = HitValueEnum.Missed;
                                }
                                for (int i = ship.YPos; i < ship.YPos + ship.Size; i++)
                                {
                                    if (i == Missle.YPos)
                                    {
                                        Missle.IsHit = HitValueEnum.Hitted;
                                    }
                                    else
                                    {
                                        Missle.IsHit = HitValueEnum.Missed;
                                    }

                                }
                                break;
                        }

                    }
                    hitList.ListOfHit.Add(Missle);
                }
                else
                    hit = false;
                IsHit = Missle.IsHit;
            }
            return hit;
        }     
    }
}
