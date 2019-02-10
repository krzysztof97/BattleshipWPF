using BattleshipCore.Models;
using BattleshipCore.Models.Players.Hit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Logic2
{
    class ShipDestroyer
    {
        string message;
        public string Message { get => message; set => message = value; }

        public ShipDestroyer(Armada armada, Ship ship, HitMissle missle)
        {
            if (missle.IsHit == HitValueEnum.Hitted)
            {
                ship.Live--;

                if (ship.Live == 0)
                {
                    Message = $"zniszczono {ship.Name}";
                    armada.Army.Remove(ship);
                }
            }
        }

    }
}
