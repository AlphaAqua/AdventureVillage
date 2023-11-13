using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureVillageLibrary.Class;

namespace AdventureVillageLibrary.Interfaces
{
    public interface IMovable : IPositionable
    {
        float Speed { get; }

        Position Destination { get; set; }

        void SetDestination(Position destination);
        void SetDestination(IPositionable destination);

        bool Move(IMovable entity);
    }
}
