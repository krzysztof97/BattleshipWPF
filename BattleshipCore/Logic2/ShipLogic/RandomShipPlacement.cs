using BattleshipCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2.ShipLogic
{
    /// <summary>
    /// Class to set Random Ship Placement for AIAdmiral
    /// </summary>
    public class RandomShipPlacement
    {
        Armada armada;

        public Dictionary<Type, int> ShipsQuantity { get; private set; } = new Dictionary<Type, int>()
        {
            { typeof(AircraftCarrier), AircraftCarrier.ShipCount },
            { typeof(BattleShip), BattleShip.ShipCount },
            { typeof(Cruiser), Cruiser.ShipCount },
            { typeof(Destroyer), Destroyer.ShipCount }
        };
        public Armada Armada { get => armada; set => armada = value; }

        public RandomShipPlacement()
        {
            GenerateArmada();
        }

        private void GenerateArmada()
        {
            Random rnd = new Random();
            ShipPlacement shipPlacement = new ShipPlacement();

            foreach (var left in ShipsQuantity)
            {
                for(int i = 0; i < left.Value; i++)
                {
                    bool success;
                    do
                    {
                        OrientationEnum orientation = (rnd.Next() % 2 == 0) ? OrientationEnum.Horizontal : OrientationEnum.Vertical;
                        Ship ship = (Ship)Activator.CreateInstance(left.Key, orientation);
                        ship.XPos = rnd.Next(10);
                        ship.YPos = rnd.Next(10);

                        success = shipPlacement.ShipDeploy(ship);


                    } while (!success);
                }
            }

            armada = shipPlacement.Armada;
        }
    }
}
