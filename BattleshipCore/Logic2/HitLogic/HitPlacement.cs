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
        HitValueEnum isHit;
        ShipDestroyer shipDestroyer;
        HitList hitList = new HitList();
        public HitValueEnum IsHit { get => isHit; set => isHit = value; }


        public bool Placemen(Armada armada, HitMissle missle)
        {
            bool hit = false;
            foreach (var bomb in hitList.ListOfHit)
            {
                if (!(bomb.XPos == missle.XPos) || !(bomb.YPos == missle.YPos))
                {
                    foreach (var aShip in armada.Army)
                    {
                        if (Free.IsFreeShip(aShip, missle.XPos, missle.YPos))
                        {
                            IsHit = HitValueEnum.Missed;
                            hit = false;
                        }
                        else
                        {
                            IsHit = HitValueEnum.Hit;
                            shipDestroyer = new ShipDestroyer(armada, aShip, IsHit);
                            hit = true;
                        }

                    }
                    hitList.ListOfHit.Add(missle);
                }
                else continue;
            }
            return hit;
        }
    }
}
