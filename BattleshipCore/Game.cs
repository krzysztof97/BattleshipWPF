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
            if (ShipsLeft[ship.GetType()] == 0)
                return false;

            if (shipPlacement.ShipDeploy(ship))
            {
                ShipsLeft[ship.GetType()]--;
                return true;
            }

            return false;
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

        public Dictionary<Type, int> ShipsLeft { get; private set; } = new Dictionary<Type, int>()
        {
            { typeof(AircraftCarrier), AircraftCarrier.ShipCount },
            { typeof(BattleShip), BattleShip.ShipCount },
            { typeof(Cruiser), Cruiser.ShipCount },
            { typeof(Destroyer), Destroyer.ShipCount }
        };
    }
}
