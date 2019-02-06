using System;

namespace BattleshipCore.Models
{
    public class Ship
    {

        private int size;
        private string name;
        private OrientationEnum orientation;
        private int shipCount;
        private int xPos;
        prive int yPos;

        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public OrientationEnum Orientation { get => orientation; set => orientation = value; }
        public int ShipCount { get => shipCount; set => shipCount = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
    }
}