using System;
using BattleshipCore.Logic2;
using BattleshipCore.Models;
using BattleshipCore.Models.Players;
using BattleshipCore.Models.Players.Hit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBattleshipCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(2, 3)]
        [DataRow(4, 8)]
        [DataRow(10, 0)]
        [DataRow(1, 2)]
        [DataRow(5, 8)]
        [DataRow(0, 0)]
        [DataRow(10, 10)]
        public void ShipDeployTest(int x, int y)
        {
            Ship s = new Ship
            {
                XPos = x,
                YPos = y
            };

            ShipPlacement shipPla = new ShipPlacement();

            shipPla.ShipDeploy(s);

            Assert.IsTrue(true);
        }
        [TestMethod]
        [DataRow(11, 12)]
        [DataRow(13, 20)]
        [DataRow(40, 100)]
        [DataRow(11, 9)]
        [DataRow(3, 17)]
        [DataRow(2, 3)]
        [DataRow(4, 8)]
        [DataRow(10, 0)]
        [DataRow(1, 2)]
        [DataRow(5, 8)]
        [DataRow(0, 0)]
        [DataRow(10, 10)]
        public void ShipDeployTest2(int x, int y)
        {
            Ship s = new Ship
            {
                XPos = x,
                YPos = y
            };

            ShipPlacement shipPla = new ShipPlacement();

            shipPla.ShipDeploy(s);

            Ship s2 = new Ship();
            s.XPos = x;
            s.YPos = y;
            shipPla.ShipDeploy(s2);

            Assert.IsFalse(false);
        }
        [TestMethod]
        [DataRow(2, 3)]
        [DataRow(4, 8)]
        [DataRow(10, 0)]
        [DataRow(1, 2)]
        [DataRow(5, 8)]
        [DataRow(0, 0)]
        [DataRow(10, 10)]
        public void HitPlacementTest(int x, int y)
        {
            HitMissle missle = new HitMissle(x, y);
            HitList hitList = new HitList();
            Ship ship = new Ship();
            HitPlacement hitPla = new HitPlacement();
            ShipPlacement shipPla = new ShipPlacement();
            Player player = new Player();

            shipPla.ShipDeploy(ship);
            hitPla.Placemen(shipPla.Armada, hitList, x, y, player);
            Assert.IsTrue(true);
        }

        

        [TestMethod]
        [DataRow(2, 3, 2, 3)]
        [DataRow(4, 8, 4, 8)]
        [DataRow(10, 0, 10, 0)]
        [DataRow(1, 2, 1, 2)]
        [DataRow(5, 8, 5, 8)]
        [DataRow(0, 0, 5, 8)]
        [DataRow(10, 10, 10, 10)]
        public void HitPlacementTest4(int x, int y, int sX, int sY)
        {
            HitList hitList = new HitList();
            Armada armada = new Armada();
            Ship ship = new Ship();
            HitPlacement hitPla = new HitPlacement();
            Player player = new Player();

            ship.XPos = sX;
            ship.YPos = sY;

            hitPla.Placemen(armada, hitList, x, y, player);

            hitPla.Placemen(armada, hitList, x, y, player);


            Assert.IsFalse(false);


        }

    }

}