namespace BattleshipCore.Models
{
    public class Cruiser : Ship
    {
        public Cruiser(OrientationEnum orientation)
        {
            this.Size = 2;
            this.Name = "Krążownik";
            this.Orientation = orientation;
            this.ShipCount = 3;
            this.Live = 2;
        }
    }
}