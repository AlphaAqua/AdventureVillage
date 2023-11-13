using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AdventureVillageLibrary.Enum;

namespace AdventureVillageLibrary.Class
{

    internal class TerritoryTemplate
    {
        public string Name;
        public Biome Biome;
        public int DangerLevel;

        public TerritoryTemplate(string name, Biome biome, int dangerLevel)
        {
            Name = name;
            Biome = biome;
            DangerLevel = dangerLevel;
        }
    }

    internal static class TerritoryTemplateList
    {
        public static readonly TerritoryTemplate[] Territories = new TerritoryTemplate[]
        {
            new TerritoryTemplate("Beautiful Plains", Biome.Plains, 1),
            new TerritoryTemplate("Frigid Wasteland", Biome.Snow, 5),
            new TerritoryTemplate("Blazing Canyon", Biome.Fire, 4),
            new TerritoryTemplate("Serenity Forest", Biome.Forest, 2),
            new TerritoryTemplate("Thunderous Mountains", Biome.Mountains, 4),
            new TerritoryTemplate("Mystical Highlands", Biome.Mountains, 3),
            new TerritoryTemplate("Whispering Woods", Biome.Forest, 2),
            new TerritoryTemplate("Emerald Meadows", Biome.Plains, 1),
            new TerritoryTemplate("Stormy Seas", Biome.Ocean, 5),
            new TerritoryTemplate("Tranquil Lakeside", Biome.Ocean, 2),
            new TerritoryTemplate("Haunted Ruins", Biome.City, 4),
            new TerritoryTemplate("Sunken Metropolis", Biome.City, 5),
            new TerritoryTemplate("Crimson Grove", Biome.Forest, 3),
            new TerritoryTemplate("Frostfire Ridge", Biome.Mountains, 4),
            new TerritoryTemplate("Dusk Valley", Biome.Plains, 2),
            new TerritoryTemplate("Lush Basin", Biome.Forest, 1),
            new TerritoryTemplate("Forgotten Isle", Biome.Ocean, 4),
            new TerritoryTemplate("Burning Sands", Biome.Fire, 4),
            new TerritoryTemplate("Gleaming Glacier", Biome.Snow, 2),
            new TerritoryTemplate("Ancient Savannah", Biome.Plains, 2),
            new TerritoryTemplate("Shadowed Pines", Biome.Forest, 3),
            new TerritoryTemplate("Celestial Shore", Biome.Ocean, 2),
            new TerritoryTemplate("Desolate Barrens", Biome.Fire, 5),
            new TerritoryTemplate("Icy Expanse", Biome.Snow, 4),
            new TerritoryTemplate("Lost Jungle", Biome.Forest, 3),
            new TerritoryTemplate("Thundering Plateau", Biome.Plains, 3),
            new TerritoryTemplate("Coral Lagoon", Biome.Ocean, 1),
            new TerritoryTemplate("Smoldering Peaks", Biome.Mountains, 5),
            new TerritoryTemplate("Frozen Depths", Biome.Snow, 4),
            new TerritoryTemplate("Abandoned Citadel", Biome.City, 3),
            new TerritoryTemplate("Verdant Dale", Biome.Plains, 1),
            new TerritoryTemplate("Bewitched Forest", Biome.Forest, 4),
            new TerritoryTemplate("Tempest Ocean", Biome.Ocean, 5),
            new TerritoryTemplate("Scorched Earth", Biome.Fire, 5),
            new TerritoryTemplate("Glistening Bluffs", Biome.Mountains, 2),
            new TerritoryTemplate("Polar Frontier", Biome.Snow, 3),
            new TerritoryTemplate("Twilight Grove", Biome.Forest, 2),
            new TerritoryTemplate("Silent Savannah", Biome.Plains, 1),
            new TerritoryTemplate("Raging Seas", Biome.Ocean, 5),
            new TerritoryTemplate("Inferno Valley", Biome.Fire, 4),
            new TerritoryTemplate("Sunset Mountains", Biome.Mountains, 3),
            new TerritoryTemplate("Frozen Tundra", Biome.Snow, 5),
            new TerritoryTemplate("Eerie Downtown", Biome.City, 4),
            new TerritoryTemplate("Starlit Meadows", Biome.Plains, 1),
            new TerritoryTemplate("Enchanted Woods", Biome.Forest, 2),
            new TerritoryTemplate("Mystic Beach", Biome.Ocean, 3),
            new TerritoryTemplate("Lava Lakes", Biome.Fire, 4)
        };
        private static int index = new Random().Next(Territories.Length);

        public static TerritoryTemplate GetNextTemplate()
        {
            index = (index + 1) % Territories.Length;
            return Territories[index];
        }
    }
}
