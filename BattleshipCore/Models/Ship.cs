using System;

namespace BattleshipCore.Models {
    public class Ship {
        private int armor;
        private int size;
        private string name;
        private char orientation;

        public int Armor { get => armor; set => armor = value; }
        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public char Orientation { get => orientation; set => orientation = value; }
    }
}