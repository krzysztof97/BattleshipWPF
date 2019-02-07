namespace BattleshipCore.Models
{
    public class ShipPlacement
    {
        Armada armada = new Armada();

        public bool ShipDeploy(Ship ship, int xPos, int yPos)
        {
            bool isDeploy = false;

            foreach (var aship in armada.Army)
            {
                switch (ship.Orientation)
                {
                    case OrientationEnum.Horizontal:

                        if (Free.IsFree(aship.XPos, aship.XPos + aship.Size, xPos))
                        {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add(ship);

                            isDeploy = true;
                        }
                        else
                            isDeploy = false;
                        break;
                    case OrientationEnum.Vertical:

                        if (Free.IsFree(aship.YPos, aship.YPos + aship.Size, yPos))
                        {
                            ship.XPos = xPos;
                            ship.YPos = yPos;
                            ship.ShipCount--;
                            armada.Army.Add(ship);

                            isDeploy = true;
                        }
                        else
                            isDeploy = false;
                        break;
                }

            }

            if (ship.ShipCount == 0)
            {
                ship.Wisibility = false;
            }
            return isDeploy;
        }

        //public static bool IsFree(int min, int max, int value)
        //{
        //    bool isFree = false;

        //    for (int i = min; i < max; i++)
        //    {
        //        if (i == value)
        //        {
        //            isFree = false;
        //        }
        //        else
        //            isFree = true;
        //    }
        //    return isFree;
        }

    }
}