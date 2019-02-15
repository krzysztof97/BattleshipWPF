namespace BattleshipCore.Models
{
    ///<summary>
    ///Two flagpole ship. Class inherit to Ship class
    ///</sumary>
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