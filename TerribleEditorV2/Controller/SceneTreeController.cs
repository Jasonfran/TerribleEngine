using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Web.ModelBinding;
using System.Windows.Data;
using TerribleEditorV2.Events;
using TerribleEditorV2.Models;
using TerribleEditorV2.Models.SceneTree;
using TerribleEditorV2.Services;
using TerribleEngine.ECS;
using EventManager = TerribleEditorV2.Services.EventManager;
using IEventManager = TerribleEditorV2.Services.IEventManager;

namespace TerribleEditorV2.Controller
{
    public class SceneTreeController : ISceneTreeController
    {
        private readonly IEventManager _eventManager;
        public SceneTreeViewModel Model { get; }

        private ConcurrentDictionary<IEntity, EntityNodeViewModel> EntityToViewModel { get; }

        public SceneTreeController(IEventManager eventManager)
        {
            _eventManager = eventManager;
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

        public void SelectedItemChanged(object item)
        {
            _eventManager.RaiseEvent(new SelectedSceneItemChanged(item));
        }
    }
}