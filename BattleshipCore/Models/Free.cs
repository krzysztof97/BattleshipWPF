using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models
{
    class Free
    {
        public static bool IsFree(int min, int max, int value)
        {
            bool isFree = true;

            for (int i = min; i < max; i++)
            {
                if (i == value)
                {
                    isFree = false;
                }
            }
            return isFree;
        }
    }
}
