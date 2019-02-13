namespace BattleshipCore.Models
{
    ///<summary>
    ///One flagpole ship. Class inherit to Ship class
    ///</summary>
    public class Destroyer : Ship
    {
        public static int ShipCount = 4;
       
        public Destroyer(OrientationEnum orientation)
        {
            this.Size = 1;
            this.Name = "Niszczyciel";
            this.Orientation = orientation;
            this.Live = 1;
        }
    }
}