using System;

namespace BattleshipCore.Models {
    public class Ship {

        private int size;
        private string name;
        private OrientationEnum orientation;
        private bool wisibility = true;
        private int xPos;
        private int yPos;
        private int live;

        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public OrientationEnum Orientation { get => orientation; set => orientation = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public bool Wisibility { get => wisibility; set => wisibility = value; }
        public int Live { get => live; set => live = value; }

    }
}