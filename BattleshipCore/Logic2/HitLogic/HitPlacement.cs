using BattleshipCore.Models;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2
{
    /// <summary>
    /// Logic class. Use to add to List of HitMissle object.
    /// </summary>
    public class HitPlacement
    {
        private HitMissle missle;       
        public HitMissle Missle { get => missle; set => missle = value; }

        private ShipDestroyer shipDestroyer;
        public ShipDestroyer ShipDestr { get => shipDestroyer; set => shipDestroyer = value; }

        public bool Placemen(Armada armada, HitList hitList, int xPos, int yPos, Player player)
        {
            Missle = new HitMissle(xPos, yPos);

            if(hitList.ListOfHit.Where(x => x.XPos == xPos && x.YPos == yPos).Any())
            {
                return false;
            }
            
            Missle.IsHit = HitValueEnum.Missed;
            
            foreach (var ship in armada.Army)
            {
               
                if (Exists.Ship(xPos, yPos, ship))
                {
                    Missle.IsHit = HitValueEnum.Hitted;
                    ShipDestr = new ShipDestroyer(ship, player);
                }

            }

            hitList.ListOfHit.Add(Missle);
            return true;
        }     
    }
}
