using TerribleEngine.ECS;

namespace TerribleEditorV2.Models.SceneTree
{
    public class ComponentNodeViewModel
    {
        public IComponent Component { get; }
        public string Name { get; }

        public ComponentNodeViewModel(IComponent component)
        {
            Component = component;
            Name = component.GetType().Name;
        }
    }
}