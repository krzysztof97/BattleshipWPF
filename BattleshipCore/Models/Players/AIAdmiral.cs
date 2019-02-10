using BattleshipCore.Logic2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipCore.Models.Players;
using BattleshipCore.Models.Players.Hit;

namespace BattleshipCore.Models.Players
{
    public class AIAdmiral : Player
    {

        HitPlacement hitPlacement = new HitPlacement();
        HitList hitList = new HitList();
        AIRandoHit randomHit = new AIRandoHit();
        Armada armada;
        internal HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }

        public AIAdmiral()
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
            this.Turn = false;
        }


        public void MisslePush()
        {
            if (Turn)
            {
                int valueX = randomHit.AIRandoHi();
                int valueY = randomHit.AIRandoHi();
                HitMissle missle = new HitMissle(valueX, valueY);
                HitPlacement.Placemen(Armada, missle, HitList);


                switch (missle.IsHit)
                {
                    case HitValueEnum.Hitted:
                        Turn = true;
                        break;
                    case HitValueEnum.Missed:
                        Turn = false;
                        break;
                }
            }

        }

    }
}
