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
                if (!Free.IsFreeShip(aship, ship.XPos, ship.YPos))
                {
                    isDeploy = false;
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
                ship.ShipCount--;
            }

            if (ship.ShipCount == 0)
            {
                ship.Wisibility = false;
            }

            return isDeploy;
        }

    }
}