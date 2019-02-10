using BattleshipCore.Logic2;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players
{
    
    public class User : Player
    {
        HitPlacement hitPlacement = new HitPlacement();
        HitList hitList = new HitList();
        Armada armada = new Armada();
        AIAdmiral admiral;
        public HitPlacement HitPlacement { get => hitPlacement; set => hitPlacement = value; }
        public HitList HitList { get => hitList; set => hitList = value; }
        public Armada Armada { get => armada; set => armada = value; }
        public AIAdmiral Admiral { get => admiral; set => admiral = value; }
        public HitValueEnum LastHitMissleState;

        public User(string name, AIAdmiral admiral, Armada armada)
        {
            this.Name = name;
            this.Wins = 0;
            this.Turn = true;
            this.Admiral = admiral;
            this.Armada = armada;
        }
        public bool MisslePush(int xPos, int yPos)
        {
            if (Turn)
            {
                int valueX = xPos;
                int valueY = yPos;
                HitMissle missle = new HitMissle(valueX, valueY);
                bool isHit = HitPlacement.Placemen(Armada, missle, HitList);
                LastHitMissleState = missle.IsHit;

                switch (missle.IsHit)
                {
                    case HitValueEnum.Hitted:
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
