using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.GameObjects
{
    public class Owner : GameObject
    {
        public string Name;
        public string Secret;

        public Owner(string name, string uniqueIdentifier, string secret)
        {
            Name = name;
            Secret = secret;
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(uniqueIdentifier));
                ID = new Guid(hash);
            }
        }
    }
}
