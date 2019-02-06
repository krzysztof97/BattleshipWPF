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


        public HitPlacement(Armada armada, Ship ship, int xPos, int yPos)
        {
            foreach (var aShip in armada.Army)
            {
                if (IsFree(aShip.XPos, aShip.XPos + aShip.Size, xPos) && IsFree(aShip.YPos, aShip.YPos + aShip.Size, yPos))
                {
                    IsHit = HitValueEnum.Missed;
                }
                else
                {
                    IsHit = HitValueEnum.Hit;
                    shipDestroyer = new ShipDestroyer(armada, ship, IsHit);
                }

            }
        }


        public static bool IsFree(int min, int max, int value)
        {
            bool isFree = false;

            for (int i = min; i < max; i++)
            {
                if (i == value)
                {
                    isFree = false;
                }
                else
                    isFree = true;
            }
            return isFree;
        }
    }
}
