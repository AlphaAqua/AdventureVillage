using AdventureVillageLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.GameObjects
{
    public abstract class Building : GameObject
    {
        public string Name { get; } = "";
        public BuildingType Type { get; }

        [JsonConstructor]
        public Building() { }


        public Building(BuildingType type, string? name = "")
        {
            Type = type;
            if (name == null)
            {
                Name = Type.ToString();
            }
            else
            {
                Name = name;
            }
        }
    }
}
