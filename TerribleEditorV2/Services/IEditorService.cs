namespace TerribleEditorV2.Services
{
    public interface IEditorService
    {
        void SetSelectedSceneItem(object item);
        object GetSelectedSceneItem();
    }
}