using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.GameObjects
{
    public class Owner : GameObject
    {
        public string Name = "";
        public string Secret = "";

        [JsonConstructor]
        public Owner() { }

        public Owner(string name, Guid uniqueIdentifier, string secret)
        {
            Name = name;
            Secret = secret;
            ID = uniqueIdentifier;
        }
    }
}
