namespace BattleshipCore.Models
{
    /// <summary>
    /// class which has Dleploy methods
    /// </summary>
    public class ShipPlacement
    {
        /// <param name="armada">declare Armada object</param>
        private Armada armada;
        public Armada Armada => armada;
        /// <summary>
        /// Constructor class
        /// </summary>
        public ShipPlacement()
        {
            armada = new Armada();
        }
        /// <summary>
        /// Method whose add Ship object to List Of ship.
        /// </summary>
        /// <param name="ship">  Ship object </param>
        /// <returns>bool value</returns>
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