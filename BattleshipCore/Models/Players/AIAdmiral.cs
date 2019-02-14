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
        Armada armada;
        User user;
        internal HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }
        public User User { get => user; set => user = value; }
        public HitMissle LastHitMissle;

        private ShipDestroyer shipDestroyer;
        public ShipDestroyer ShipDestr { get => shipDestroyer; set => shipDestroyer = value; }

        public AIAdmiral()
        {
            this.Name = "Admirał Bismarck";
            this.Wins = 0;
            this.Turn = false;
            GenerateArmada();
        }


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

        public void GenerateArmada()
        {
            RandomShipPlacement rsp = new RandomShipPlacement();
            this.Armada = rsp.Armada;
        }

    }
}
