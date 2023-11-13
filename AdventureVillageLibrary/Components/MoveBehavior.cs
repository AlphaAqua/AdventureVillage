using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventureVillageLibrary.Class;
using AdventureVillageLibrary.Interfaces;

namespace AdventureVillageLibrary.Components
{
    public static class MoveBehavior
    {
        public static void SetDestination(IMovable me, Position destination)
        {
            me.Destination = destination;
        }

        public static void SetDestination(IMovable me, IPositionable destination)
        {
            me.Destination = destination.Position;
        }

        public static Position? Move(IMovable me)
        {
            if (me.Destination == null)
            {
                return null;
            }
            else
            {
                if (me.Position.DistanceTo(me.Destination) < me.Speed)
                {
                    return me.Destination;
                }
                else
                {
                    Position direction = (me.Destination - me.Position).Normalize();
                    Position movement = direction * me.Speed;
                    return me.Position + movement;
                }
            }
        }
    }
}
