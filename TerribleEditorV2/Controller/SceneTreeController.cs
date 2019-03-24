using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Web.ModelBinding;
using System.Windows.Data;
using TerribleEditorV2.Models;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Controller
{
    public class SceneTreeController : ISceneTreeController
    {
        private object _entityCollectionLock = new object();
        public SceneTreeViewModel Model { get; }

        private ConcurrentDictionary<IEntity, EntityNodeViewModel> EntityToViewModel { get; }

        public SceneTreeController()
        {
            EntityToViewModel = new ConcurrentDictionary<IEntity, EntityNodeViewModel>();

            Model = new SceneTreeViewModel();
            BindingOperations.EnableCollectionSynchronization(Model.Entities, _entityCollectionLock);
        }

        public void AddEntity(IEntity entity)
        {
            var viewModel = new EntityNodeViewModel(entity);
            EntityToViewModel.TryAdd(entity, viewModel);
            Model.Entities.Add(viewModel);
        }

        public void AddChild(IEntity parent, IEntity child)
        {
            if (!EntityToViewModel.ContainsKey(parent)) return;
            var viewModel = new EntityNodeViewModel(child);
            EntityToViewModel[parent].Children.Add(viewModel);
        }
    }
}