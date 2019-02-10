using System;
using BattleshipCore.Models;
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
            Ship s = new Ship();
            s.XPos = x;
            s.YPos = y;

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
            Ship s = new Ship();
            s.XPos = x;
            s.YPos = y;

            ShipPlacement shipPla = new ShipPlacement();

            shipPla.ShipDeploy(s);

            Ship s2 = new Ship();
            s.XPos = x;
            s.YPos = y;
            shipPla.ShipDeploy(s2);

            Assert.IsFalse(false);
        }
    }
}