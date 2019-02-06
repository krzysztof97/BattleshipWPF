using System.Collections.Generic;

namespace BattleshipCore.Models
{
    public class Armada
    {
        private List<Ship> army = new List<Ship>();

        public List<Ship> Army { get => army; set => army = value; }

    }
}