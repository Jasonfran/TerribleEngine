using TerribleEngine.ECS;
using TerribleEngine.Resources;

namespace TerribleEngine.ComponentModels
{
    public class Renderable : IComponent
    {
        public Model Model { get; set; }
        public Material Material { get; set; }
    }
}