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
    public class AIAdmiral : Player
    {

        HitPlacement hitPlacement = new HitPlacement();
        HitList hitList = new HitList();
        AIRandoHit randomHit = new AIRandoHit();
        Armada armada;
        User user;
        internal HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }
        public User User { get => user; set => user = value; }

        public AIAdmiral(User user)
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
            this.Turn = false;
            this.User = user;
            GenerateArmada();
        }


        public void MisslePush()
        {
            if (Turn)
            {
                int valueX = randomHit.AIRandoHi();
                int valueY = randomHit.AIRandoHi();
                HitMissle missle = new HitMissle(valueX, valueY);
                HitPlacement.Placemen(Armada, HitList, valueX, valueY);


                switch (missle.IsHit)
                {
                    case HitValueEnum.Hitted:
                        Turn = true;
                        break;
                    case HitValueEnum.Missed:
                        Turn = false;
                        User.Turn = true;
                        break;
                }
            }

        }

        public void GenerateArmada()
        {
            RandomShipPlacement rsp = new RandomShipPlacement();
            this.Armada = rsp.Armada;
        }

    }
}
