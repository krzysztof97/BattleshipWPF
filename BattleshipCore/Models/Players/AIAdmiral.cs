using BattleshipCore.Logic2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipCore.Models.Players;
using BattleshipCore.Models.Players.Hit;
using BattleshipCore.Logic2.ShipLogic;

namespace BattleshipCore.Models.Players
{
    /// <summary>
    /// AI Player class.
    /// </summary>
    public class AIAdmiral : Player
    {
        /// <param name="hitPlacement">declare HitPlacement object</param>
        /// <param name="hitList">declare hitList object</param>
        /// <param name="armada">declare Armada object</param>
        /// <param name="user">declare User object</param>

        HitPlacement hitPlacement = new HitPlacement();
        HitList hitList = new HitList();
        Armada armada;
        User user;
        internal HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }
        public User User { get => user; set => user = value; }
        public HitMissle LastHitMissle;

        private ShipDestroyer shipDestroyer;
        public ShipDestroyer ShipDestr { get => shipDestroyer; set => shipDestroyer = value; }

        /// <summary>
        /// Constructor class.
        /// </summary>
        public AIAdmiral()
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
            this.Turn = false;
            GenerateArmada();
        }

        /// <summary>
        /// add HitMissle Object to HitList List(hitList).
        /// </summary>
        /// <returns>isHit bool value</returns>
        public bool MisslePush()
        {
            Random rnd = new Random();
            if (Turn)
            {
                bool isHit;
                do
                {
                    int valueX = rnd.Next(10);
                    int valueY = rnd.Next(10);
                    isHit = HitPlacement.Placemen(User.Armada, HitList, valueX, valueY, this);
                    LastHitMissle = HitPlacement.Missle;

                    switch (LastHitMissle.IsHit)
                    {
                        case HitValueEnum.Hitted:
                            ShipDestr = HitPlacement.ShipDestr;
                            Turn = true;
                            break;
                        case HitValueEnum.Missed:
                            Turn = false;
                            User.Turn = true;
                            break;
                    }
                } while (!isHit);
               
                return isHit;
            }

            return false;
        }
        /// <summary>
        /// Declare list of ship for AI.
        /// </summary>
        public void GenerateArmada()
        {
            RandomShipPlacement rsp = new RandomShipPlacement();
            this.Armada = rsp.Armada;
        }

    }
}
