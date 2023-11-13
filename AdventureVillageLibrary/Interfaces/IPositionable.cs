using AdventureVillageLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.Interfaces
{
    public interface IPositionable
    {
        Position Position { get; }

        float DistanceTo(IPositionable other);
    }
}
