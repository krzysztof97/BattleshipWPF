namespace BattleshipCore.Models {
    public class Destroyer : Ship {
        public Destroyer (char orientation) {
            this.Armor = 2;
            this.Size = 2;
            this.Name = "Niszczyciel";
            //to do orientation
        }
    }
}