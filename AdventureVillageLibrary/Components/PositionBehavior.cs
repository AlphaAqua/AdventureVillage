using AdventureVillageLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.Components
{
    public static class PositionBehavior
    {
        public static float DistanceTo(IPositionable me, IPositionable other)
        {
            return me.DistanceTo(other);
        }

    }
}
