using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players.Hit
{
    /// <summary>
    /// Basic class to Hit Logic.
    /// </summary>
    public class HitMissle
    {
        /// <param name="xPos">horizonatal point</param>
        /// <param name="yPos">vertical point</param>
        private int xPos;
        private int yPos;
        HitValueEnum isHit;

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public HitValueEnum IsHit { get => isHit; set => isHit = value; }

        /// <summary>
        /// Constructor class.
        /// </summary>
        /// <param name="xPos"> get horizontal point</param>
        /// <param name="yPos">get vertical point</param>
        public HitMissle(int xPos, int yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
        }
    }
}
