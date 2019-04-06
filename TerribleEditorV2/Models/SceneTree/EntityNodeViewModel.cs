using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Models.SceneTree
{
    public class EntityNodeViewModel
    {
        public int Id { get; set; }
        public IEntity Entity { get; set; }
        public ObservableCollection<ComponentNodeViewModel> Components { get; set; }
        public ObservableCollection<EntityNodeViewModel> Entities { get; set; }

        public CompositeCollection Children
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() {Collection = Components},
                    new CollectionContainer() {Collection = Entities}
                };
            }
        }

        public EntityNodeViewModel(IEntity entity)
        {
            Components = new ObservableCollection<ComponentNodeViewModel>();
            Entities = new ObservableCollection<EntityNodeViewModel>();

            Id = entity.Id;
            Entity = entity;
        }

        public EntityNodeViewModel()
        {
        }
    }
}