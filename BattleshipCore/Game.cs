using BattleshipCore.Logic2;
using BattleshipCore.Models;
using BattleshipCore.Models.Players;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore
{
    public class Game
    {
        AIAdmiral admiral;
        private ShipPlacement shipPlacement;
        public int testint = 1;
        HitMissle missle;

        public Game()
        {
            admiral = new AIAdmiral();
            shipPlacement = new ShipPlacement();
        }

        public bool ShipDeploy(Ship ship)
        {
            return shipPlacement.ShipDeploy(ship);
        }

        public bool AIHitPlacemet()
        {
            return admiral.HitPlacement.Placemen(shipPlacement.Armada, missle);
        }
        public IEnumerable<Ship> Armada
        {
            get
            {
                foreach (Ship ship in shipPlacement.Armada.Army)
                {
                    yield return ship;
                }
            }
        }
    }
}
