using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Models
{
    public class EntityNodeViewModel
    {
        public int Id { get; set; }
        public IEntity Entity { get; set; }
        public List<string> Components { get; set; }
        public List<EntityNodeViewModel> Children { get; set; }

        public EntityNodeViewModel(IEntity entity)
        {
            Components = new List<string>();
            Children = new List<EntityNodeViewModel>();

            Id = entity.Id;
            Entity = entity;
        }

        public EntityNodeViewModel()
        {
        }
    }
}