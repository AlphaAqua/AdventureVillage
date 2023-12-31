﻿using AdventureVillageLibrary.Class;
using AdventureVillageLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.GameObjects
{
    public class Village : GameObject, IPositionable
    {
        public string Name { get; set; } = "";
        public Position Position { get; private set; } = new Position(-1, -1);

        [JsonConstructor]
        public Village() { }

        public Village(Position position, string? name)
        {
            if (name == null)
            {
              Name = "MyVillage";
            }
            else
            {
                Name = name;
            }
            Position = position;
        }

        public float DistanceTo(IPositionable other)
        {
            return Position.DistanceTo(other.Position);
        }
    }
}
