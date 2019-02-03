using System;

namespace BattleshipCore.Models {
    public class Ship {

        private int size;
        private string name;
        private OrientationEnum orientation;
        
        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public OrientationEnum Orientation { get => orientation; set => orientation = value; }

    }
}