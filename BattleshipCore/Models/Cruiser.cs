namespace BattleshipCore.Models {
    public class Cruiser : Ship {
        public Cruiser (char orientation) {
            this.Armor = 2;
            this.Size = 2;
            this.Name = "Krążownik";
            //to do orientation
        }
    }
}