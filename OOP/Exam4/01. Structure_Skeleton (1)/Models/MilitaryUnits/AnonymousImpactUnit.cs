using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit, IMilitaryUnit
    {
        private const double COST = 30;

        public AnonymousImpactUnit() : base(COST)
        {
        }
    }
}
