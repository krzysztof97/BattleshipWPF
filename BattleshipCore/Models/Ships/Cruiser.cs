namespace BattleshipCore.Models
{
    public class Cruiser : Ship
    {
        public static int ShipCount = 3;
        public Cruiser(OrientationEnum orientation)
        {
            this.Size = 2;
            this.Name = "Krążownik";
            this.Orientation = orientation;
            this.Live = 2;
        }
    }
}