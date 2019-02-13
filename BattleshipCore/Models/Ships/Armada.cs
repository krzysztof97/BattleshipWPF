using System.Collections.Generic;

namespace BattleshipCore.Models
{
    public class Armada
    {
        ///<summary>
        ///Declerate List of Ship object
        ///</summary>
        private List<Ship> army = new List<Ship>();

        public List<Ship> Army { get => army; set => army = value; }

    }
}