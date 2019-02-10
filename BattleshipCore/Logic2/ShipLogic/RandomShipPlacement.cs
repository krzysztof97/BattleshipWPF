using BattleshipCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2.ShipLogic
{
    class RandomShipPlacement
    {
        public Dictionary<Type, int> ShipsLeft { get; private set; } = new Dictionary<Type, int>()
        {
            { typeof(AircraftCarrier), AircraftCarrier.ShipCount },
            { typeof(BattleShip), BattleShip.ShipCount },
            { typeof(Cruiser), Cruiser.ShipCount },
            { typeof(Destroyer), Destroyer.ShipCount }
        };
    }
}
