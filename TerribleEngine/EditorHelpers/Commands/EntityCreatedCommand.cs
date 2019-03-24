using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityCreatedCommand : ICommand
    {
        private EntityCreatedCommandParams Parameters { get; }
        private IEditorInterface EditorInterface { get; }

        public EntityCreatedCommand(EntityCreatedCommandParams parameters, IEditorInterface editorInterface)
        {
            Parameters = parameters;
            EditorInterface = editorInterface;
        }

        public void Execute()
        {
            EditorInterface.EditorEntityManager.AddEntity(Parameters.Entity);
        }
    }
}