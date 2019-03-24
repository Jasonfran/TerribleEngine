namespace TerribleEngine.EditorHelpers.Interfaces
{
    public interface IEditorInterface
    {
        IEditorEntityManager EditorEntityManager { get; }
        void ReceiveCommand(ICommand command);
    }
}