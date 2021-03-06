﻿using BattleshipCore.Models;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2
{
    /// <summary>
    /// Logic class
    /// </summary>
    public class ShipDestroyer
    {
        private string message;
        public string Message { get => message; set => message = value; }
        private Ship ship;
        public Ship Ship { get => ship; set => ship = value; }

        /// <summary>
        /// Logic method. 
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="player"></param>
        public ShipDestroyer(Ship ship, Player player)
        {
            Ship = ship;

            ship.Live--;

            if (ship.Live == 0)
            {
                Message = $"{player.Name} zniszczył {ship.Name}";
            }
        }

    }
}
