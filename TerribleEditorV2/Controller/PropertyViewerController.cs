using System.Text;
using System.Windows.Controls;
using TerribleEditorV2.Events;
using TerribleEditorV2.Models.PropertyViewer;
using TerribleEditorV2.Models.SceneTree;
using TerribleEngine.ECS;
using IEventManager = TerribleEditorV2.Services.IEventManager;

namespace TerribleEditorV2.Controller
{
    public class PropertyViewerController : IPropertyViewerController
    {
        private readonly IEventManager _eventManager;
        public PropertyViewerViewModel Model { get; }

        public PropertyViewerController(IEventManager eventManager)
        {
            _eventManager = eventManager;
            Model = new PropertyViewerViewModel();
            _eventManager.RegisterEventListener<SelectedSceneItemChanged>(SelectedItemChanged);
        }

        private void SelectedItemChanged(SelectedSceneItemChanged args)
        {
            switch (args.Item)
            {
                case EntityNodeViewModel envm:
                    Model.ObservingItem = envm.Entity.Transform;
                    break;
                case ComponentNodeViewModel cnvm:
                    Model.ObservingItem = cnvm.Component;
                    break;
            }
        }

    }
}