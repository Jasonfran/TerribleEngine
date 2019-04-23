using System.Windows.Controls;
using TerribleEditorV2.Events;
using TerribleEditorV2.Models.PropertyViewer;
using TerribleEditorV2.Services;

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
            Model.Controls.Add(new Button()
            {
                Content = args.Item.GetType().Name
            });
        }

    }
}