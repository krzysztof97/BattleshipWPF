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

        public Game()
        {
            shipPlacement = new ShipPlacement();
        }

        public bool ShipDeploy(Ship ship, int xPos, int yPos)
        {
            return shipPlacement.ShipDeploy(ship, xPos, yPos);
        }
    }
}
