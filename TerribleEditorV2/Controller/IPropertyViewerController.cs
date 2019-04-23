using TerribleEditorV2.Models.PropertyViewer;

namespace TerribleEditorV2.Controller
{
    public interface IPropertyViewerController
    {
        PropertyViewerViewModel Model { get; }
    }
}