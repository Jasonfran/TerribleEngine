using System;
using System.Collections.Generic;
using System.Linq;

namespace TerribleEngine
{
    public class ComponentSet : IEquatable<ComponentSet>
    {
        public Type[] ComponentTypes { get; }

        public ComponentSet(params Type[] componentTypes)
        {
            ComponentTypes = componentTypes;
        }

        public ComponentSet(Type[] componentTypes, Type newType)
        {
            ComponentTypes = componentTypes.Concat(new [] {newType}).ToArray();
        }

        public ComponentSet(ComponentSet componentSet, Type newType)
        {
            ComponentTypes = componentSet.ComponentTypes.Concat(new[] { newType }).ToArray();
        }

        public bool Equals(ComponentSet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ComponentTypes.SequenceEqual(other.ComponentTypes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentSet) obj);
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (Type value in ComponentTypes)
            {
                if (value != null)
                    hashcode += value.GetHashCode();
            }
            return hashcode;
        }
    }
}