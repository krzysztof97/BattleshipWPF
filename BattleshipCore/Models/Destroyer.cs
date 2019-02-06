namespace BattleshipCore.Models {
    public class Destroyer : Ship {
        public Destroyer (OrientationEnum orientation) {
            this.Size = 1;
            this.Name = "Niszczyciel";
            this.Orientation = orientation;
            this.ShipCount = 4;
        }
    }
}