using BattleshipCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2
{
    class HitPlacement
    {
        HitValueEnum isHit;
        ShipDestroyer shipDestroyer;
        public HitValueEnum IsHit { get => isHit; set => isHit = value; }


        public bool Placemen(Armada armada, Ship ship, int xPos, int yPos)
        {
            bool hit = false;
            foreach (var aShip in armada.Army)
            {
                if (aShip.XPos != xPos && aShip.YPos != yPos)
                {
                    IsHit = HitValueEnum.Missed;
                    hit = false;
                }
                else
                {
                    IsHit = HitValueEnum.Hit;
                    shipDestroyer = new ShipDestroyer(armada, ship, IsHit);
                    hit = true;
                }

            }
            return hit;
        }
    }
}
