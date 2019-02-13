namespace BattleshipCore.Models
{
    public class Cruiser : Ship
    {
        ///<summary>
        ///Two flagpole ship. Class inherit to Ship class
        ///</sumary>
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