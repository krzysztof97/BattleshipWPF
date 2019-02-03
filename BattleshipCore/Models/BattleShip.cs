namespace BattleshipCore.Models {
    public class BattleShip : Ship {
        public BattleShip (OrientationEnum orientation) {
            this.Size = 3;
            this.Name = "Pancernik";
            this.Orientation = orientation;
        }

    }
}