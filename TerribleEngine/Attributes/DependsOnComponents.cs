using System;
using System.Collections.Generic;

namespace TerribleEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DependsOnComponents : Attribute
    {
        public ComponentSet RequiredTypes { get; }

        public DependsOnComponents(params Type[] types)
        {
            RequiredTypes = new ComponentSet(types);
        }
    }
}