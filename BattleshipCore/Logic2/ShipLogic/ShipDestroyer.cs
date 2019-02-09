using BattleshipCore.Models;
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

        public ShipDestroyer(Armada armada, Ship ship, HitValueEnum hitValueEnum)
        {
            if (hitValueEnum == HitValueEnum.Hit)
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
