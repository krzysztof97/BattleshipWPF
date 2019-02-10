using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players.Hit
{
    public class HitMissle
    {
        private int xPos;
        private int yPos;
        HitValueEnum isHit;

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public HitValueEnum IsHit { get => isHit; set => isHit = value; }
    }
}
