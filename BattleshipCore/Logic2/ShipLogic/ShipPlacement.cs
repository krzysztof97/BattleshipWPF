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
               if(!Free.IsFree(aship,ship)) isDeploy= false;
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