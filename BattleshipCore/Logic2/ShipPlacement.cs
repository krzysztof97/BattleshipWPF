namespace BattleshipCore.Models
{
    public class ShipPlacement
    {
        BattleField gameField = new BattleField();
        Armada armada = new Armada();

        public ShipPlacement(Ship ship, int xPos, int yPos)
        {
            foreach (var aship in armada.Army)
            {
                switch (ship.Orientation)
                {
                    case OrientationEnum.Horizontal:

                        if (IsFree(aship.XPos,aship.Size,xPos))
                        {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add(ship);
                            gameField.ArrayField[xPos, yPos] = ship;
                        }
                        break;
                    case OrientationEnum.Vertical:

                        if (IsFree(aship.YPos, aship.Size, yPos))
                        {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add(ship);
                            gameField.ArrayField[xPos, yPos] = ship;
                        }
                        break;
                }

            }

            if (ship.ShipCount == 0)
            {
                ship.Wisibility = false;
            }
        }

        private static bool IsFree(int min, int max, int value)
        {
            bool isFree = false;

            for (int i = min; i < max; i++)
            {
                if (i == value)
                {
                    isFree = false;
                }
                else
                    isFree = true;
            }
            return isFree;
        }
    }
}