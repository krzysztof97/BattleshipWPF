﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCore.Models.Players.Hit
{
    /// <summary>
    /// Declare list of HitMissle. 
    /// </summary>
    public class HitList
    {
        private List<HitMissle> listOfHit = new List<HitMissle>();

        public List<HitMissle> ListOfHit { get => listOfHit; set => listOfHit = value; }
    }
}
