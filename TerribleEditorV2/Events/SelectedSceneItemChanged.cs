namespace TerribleEditorV2.Events
{
    public class SelectedSceneItemChanged : IEvent
    {
        public object Item { get; }

        public SelectedSceneItemChanged(object item)
        {
            Item = item;
        }
    }
}