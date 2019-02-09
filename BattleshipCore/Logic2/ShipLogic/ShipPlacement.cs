namespace BattleshipCore.Models
{
    public class ShipPlacement
    {
        private Armada armada;
        public Armada Armada => armada;

        public ShipPlacement()
        {
            armada = new Armada();
        }

        public bool ShipDeploy(Ship ship)
        {
            bool isDeploy = true;

            foreach (var aship in armada.Army)
            {
                switch (ship.Orientation)
                {
                    case OrientationEnum.Horizontal:

                        if (!Free.IsFree(aship.XPos, aship.XPos + aship.Size, ship.XPos))
                        {

                            isDeploy = false;
                        }
                        break;
                    case OrientationEnum.Vertical:

                        if (!Free.IsFree(aship.YPos, aship.YPos + aship.Size, ship.YPos))
                        {
                            isDeploy = false;
                        }
                        break;
                }
            }

            switch (ship.Orientation)
            {
                case OrientationEnum.Horizontal:
                    if (ship.XPos + (ship.Size - 1) > 9) isDeploy = false;
                    break;
                case OrientationEnum.Vertical:
                    if (ship.YPos + (ship.Size - 1) > 9) isDeploy = false;
                    break;
            }

            if (isDeploy)
            {
                armada.Army.Add(ship);
            }
            return isDeploy;
        }

    }
}