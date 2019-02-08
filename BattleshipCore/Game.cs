using BattleshipCore.Logic2;
using BattleshipCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore
{
    public class Game
    {
        private ShipPlacement shipPlacement;
        public int testint = 1;

        public Game()
        {
            shipPlacement = new ShipPlacement();
        }

        public bool ShipDeploy(Ship ship)
        {
            return shipPlacement.ShipDeploy(ship);
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
