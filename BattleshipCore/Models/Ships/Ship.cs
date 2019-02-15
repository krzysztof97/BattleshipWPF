using System;

namespace BattleshipCore.Models
{
    ///<summary>
    ///Basic class for all ship object
    ///</summary>
    public class Ship
    {
    ///<param name="size">describe what is the size of ship</param>
    ///<param name="name">describe what kind of ship we replaceses</param>
    ///<param name="orientation">describe what is the orientation of ship(horizontal or vertical)</param>
    ///<param name="xPos">describe position in Horizontal</param>
    ///<param name="yPos">describe position in Vertical</param>
    ///<param name="live">describe amount of lifes</param>
        private int size;
        private string name;
        private OrientationEnum orientation;
        private int xPos;
        private int yPos;
        private int live;

        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public OrientationEnum Orientation { get => orientation; set => orientation = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int Live { get => live; set => live = value; }

    }
}