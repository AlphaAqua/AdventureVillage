using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.Class
{
    public class Position
    {
        public float X = 0;
        public float Y = 0;

        public Position() { }

        public Position(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(a.X - b.X, a.Y - b.Y);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator *(Position a, float scalar)
        {
            return new Position(a.X * scalar, a.Y * scalar);
        }

        public float DistanceTo(Position other)
        {
            return (float)Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        public Position Normalize()
        {
            float length = DistanceTo(new Position(0, 0));
            if (length == 0) return new Position(0, 0);
            return new Position(X / length, Y / length);
        }
    }

}
