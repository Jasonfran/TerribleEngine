using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityCreatedCommand : ICommand<EntityCreatedCommandArgs>
    {
        public EntityCreatedCommandArgs Args { get; }
        private IEditorInterface EditorInterface { get; }

        public EntityCreatedCommand(EntityCreatedCommandArgs parameters, IEditorInterface editorInterface)
        {
            Args = parameters;
            EditorInterface = editorInterface;
        }

        public void Execute()
        {
            EditorInterface.EditorEntityManager.AddEntity(Args.Entity);
        }
    }
}