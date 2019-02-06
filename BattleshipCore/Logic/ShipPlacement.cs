namespace BattleshipCore.Models {
    public class ShipPlacement {
        public ShipPlacement (Ship ship, int xPos, int yPos) {
            BattleField gameField = new BattleField ();
            Armada armada = new Armada ();

            foreach (var aship in armada.Army) {
                switch (ship.Orientation) {
                    case OrientationEnum.Horizontal:

                        if (((aship.XPos != xPos) && (aship.YPos != yPos)) && (aship.YPos + (ship.Size - 1) != yPos)) {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add (ship);
                            gameField.ArrayField[xPos, yPos] = ship;

                        }
                        break;
                    case OrientationEnum.Vertical:

                        if (((aship.XPos != xPos) && (aship.YPos != yPos)) && (aship.XPos + (ship.Size - 1) != xPos)) {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add (ship);
                            gameField.ArrayField[xPos, yPos] = ship;

                        }
                        break;
                }

            }

            if (ship.ShipCount == 0) {
                ship.Wisibility = false;
            }
        }
    }
}