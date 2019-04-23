namespace TerribleEditorV2.Services
{
    public class EditorService : IEditorService
    {
        private object _selectedItem;

        public void SetSelectedSceneItem(object item)
        {
            _selectedItem = item;
        }

        public object GetSelectedSceneItem()
        {
            return _selectedItem;
        }
    }
}