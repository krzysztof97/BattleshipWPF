using BattleshipCore.Logic2;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    /// <summary>
    /// User class.
    /// </summary>
    public class User : Player
    {
        /// <param name="hitPlacement">declare HitPlacement object</param>
        /// <param name="hitList">declare hitList object</param>
        /// <param name="armada">declare Armada object</param>
        /// <param name="admiral">declare User object</param>
        HitPlacement hitPlacement = new HitPlacement();
        HitList hitList = new HitList();
        Armada armada;
        AIAdmiral admiral;
        public HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }
        public AIAdmiral Admiral { get => admiral; set => admiral = value; }
        public HitMissle LastHitMissle;

        private ShipDestroyer shipDestroyer;
        public ShipDestroyer ShipDestr { get => shipDestroyer; set => shipDestroyer = value; }

        /// <summary>
        /// Constructor Class
        /// </summary>
        /// <param name="name">Get Name of Player</param>
        /// <param name="armada">Get list of ship</param>
        public User(string name, Armada armada)
        {
            this.Name = name;
            this.Wins = 0;
            this.Turn = true;
            this.Armada = armada;
        }
        /// <summary>
        /// add HitMissle Object to HitList List(hitList)
        /// </summary>
        /// <param name="xPos">horizontal point to set Missle.YPos</param>
        /// <param name="yPos">vertical point to set Missle.YPos</param>
        /// <returns>isHit bool Value</returns>
        public bool MisslePush(int xPos, int yPos)
        {
            if (Turn)
            {
                int valueX = xPos;
                int valueY = yPos;
                bool isHit = HitPlacement.Placemen(Admiral.Armada, HitList, valueX, valueY, this);
                LastHitMissle = HitPlacement.Missle;

                switch (LastHitMissle.IsHit)
                {
                    case HitValueEnum.Hitted:
                        ShipDestr = HitPlacement.ShipDestr;
                        Turn = true;
                        break;
                    case HitValueEnum.Missed:
                        Turn = false;
                        Admiral.Turn = true;
                        break;
                }
                return isHit;
            }
            return false;

        }

    }
}
