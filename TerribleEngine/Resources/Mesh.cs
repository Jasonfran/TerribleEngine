using System.Collections.Generic;

namespace TerribleEngine.Resources
{
    public class Mesh
    {
        public List<Vertex> Vertices { get; }
        public List<uint> Indices { get; }
        public Material Material { get; set; }

        public int BaseIndex { get; set; }

        public Mesh(List<Vertex> vertices, List<uint> indices, Material material)
        {
            Vertices = vertices;
            Indices = indices;
            Material = material;
        }
    }
}