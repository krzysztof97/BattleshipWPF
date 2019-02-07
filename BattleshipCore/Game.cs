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
    }
}
