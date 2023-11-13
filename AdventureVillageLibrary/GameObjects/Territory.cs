using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventureVillageLibrary.Interfaces;
using AdventureVillageLibrary.Components;
using AdventureVillageLibrary.Enum;
using AdventureVillageLibrary.Class;

namespace AdventureVillageLibrary.GameObjects
{

    public class Territory : GameObject, IPositionable
    {
        static private Random random = new Random();
        public string Name { get; set; } = "";
        public Biome Biome { get; set; }
        public int Depth { get; set; }
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public Position Position { get; private set; }

        public Territory()
        {
            TerritoryTemplate template = TerritoryTemplateList.GetNextTemplate();
            Name = template.Name;
            Biome = template.Biome;
            Difficulty = template.DangerLevel;
            Depth = random.Next(1, 10);
            Size = random.Next(1, 3);
            Position = new Position(random.NextSingle() * 100, random.NextSingle() * 100);
        }

        public float DistanceTo(IPositionable other)
        {
            return Position.DistanceTo(other.Position);
        }
    }
}
