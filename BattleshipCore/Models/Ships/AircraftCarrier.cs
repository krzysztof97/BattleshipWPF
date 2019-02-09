namespace BattleshipCore.Models
{
    public class AircraftCarrier : Ship
    {
        public static int ShipCount = 1;
        public AircraftCarrier(OrientationEnum orientation)
        {
            this.Size = 4;
            this.Name = "Lotniskowiec";
            this.Orientation = orientation;
            this.Live = 4;
        }
    }
}