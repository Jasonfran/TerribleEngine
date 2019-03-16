using System.Collections.Generic;

namespace TerribleEngine.Resources
{
    public struct Model
    {
        public List<Mesh> Meshes { get; }
        public string Path { get; }

        public Model(string path)
        {
            Meshes = new List<Mesh>();
            Path = path;
        }
    }
}