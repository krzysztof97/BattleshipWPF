namespace BattleshipCore.Models {
    public class AircraftCarrier : Ship {
        public AircraftCarrier (char orientation) {
            this.Armor = 4;
            this.Size = 4;
            this.Name = "Lotniskowiec";
            //to do orientation
        }
    }
}