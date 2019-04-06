using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Web.ModelBinding;
using System.Windows.Data;
using TerribleEditorV2.Models;
using TerribleEditorV2.Models.SceneTree;
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
        }

        public void AddEntity(IEntity entity)
        {
            var viewModel = new EntityNodeViewModel(entity);
            var components = entity.GetAllComponents();
            foreach (var component in components)
            {
                viewModel.Components.Add(new ComponentNodeViewModel(component));
            }
            EntityToViewModel.TryAdd(entity, viewModel);
            Model.Entities.Add(viewModel);
        }

        public void AddChild(IEntity parent, IEntity child)
        {
            if (!EntityToViewModel.ContainsKey(parent)) return;

            if (EntityToViewModel.TryGetValue(child, out var existingViewModel))
            {
                Model.Entities.Remove(existingViewModel);
                EntityToViewModel[parent].Entities.Add(existingViewModel);
            }
            else
            {
                var viewModel = new EntityNodeViewModel(child);
                EntityToViewModel[parent].Entities.Add(viewModel);
            }
            
        }
    }
}