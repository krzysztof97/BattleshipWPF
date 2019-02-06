namespace BattleshipCore.Models
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(OrientationEnum orientation)
        {
            this.Size = 4;
            this.Name = "Lotniskowiec";
            this.Orientation = orientation;
            this.ShipCount = 1;
            this.Live = 4;
        }
    }
}