using System.Collections.Generic;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public interface IEntity : IEntityParent
    {
        List<IEntity> Children { get; }
        ComponentSet ComponentSet { get; }
        int Id { get; }
        Transform Transform { get; set; }
        IWorld World { get; }
        IEntity Parent { get; set; }
        T AddChild<T>(T entity) where T : IEntity;
        void SetParent(IEntity parent);
        void SetWorld(IWorld world);
        T AddComponent<T>(T component) where T : IComponent;
        T GetComponent<T>() where T : IComponent;
        bool HasComponent<T>() where T : IComponent;
        void RemoveComponent<T>() where T : IComponent;
    }
}