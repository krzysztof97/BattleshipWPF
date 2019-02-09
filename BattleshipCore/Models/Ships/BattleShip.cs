namespace BattleshipCore.Models
{
    public class BattleShip : Ship
    {
        public static int ShipCount = 2;
        public BattleShip(OrientationEnum orientation)
        {
            this.Size = 3;
            this.Name = "Pancernik";
            this.Orientation = orientation;
            this.Live = 3;
        }

    }
}