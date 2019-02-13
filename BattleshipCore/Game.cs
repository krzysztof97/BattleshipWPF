﻿using BattleshipCore.Logic2;
using BattleshipCore.Models;
using BattleshipCore.Models.Players;
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
        private User user;
        private AIAdmiral aiAdmiral;
        public int testint = 1;
        public HitValueEnum LastUserHitMissleState;

        public Game()
        {
            shipPlacement = new ShipPlacement();
            user = new User("Gracz", aiAdmiral, shipPlacement.Armada);
            aiAdmiral = new AIAdmiral(user);
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

        public bool ShipDeployReady
        {
            get
            {
                foreach(var item in ShipsLeft)
                {
                    if (item.Value > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Users' ship navy
        /// </summary>
        public IEnumerable<Ship> Armada
        {
            get
            {
                foreach (Ship ship in user.Armada.Army)
                {
                    yield return ship;
                }
            }
        }

        /// <summary>
        /// Opponent's(Admiral's) ship navy
        /// </summary>
        public IEnumerable<Ship> OpponentArmada
        {
            get
            {
                foreach (Ship ship in aiAdmiral.Armada.Army)
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

        public bool HitShip(int xPos, int yPos)
        {
            if (user.MisslePush(xPos, yPos)) {
                LastUserHitMissleState = user.LastHitMissleState;
                return true;
            }
            return false;
        }
    }
}
