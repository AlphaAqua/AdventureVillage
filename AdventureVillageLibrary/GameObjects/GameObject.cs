using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.GameObjects
{
    public abstract class GameObject : IEquatable<GameObject>
    {
        public Guid ID { get; init;  } = Guid.NewGuid();
        public Owner? Owner { get; }

        public bool Equals(GameObject? other)
        {
            return ID.Equals(other?.ID);
        }
        public bool Equals(Guid? other)
        {
            return ID.Equals(other);
        }
    }
}
