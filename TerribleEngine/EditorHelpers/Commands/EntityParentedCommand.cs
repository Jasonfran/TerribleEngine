using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityParentedCommand : ICommand<EntityParentedCommandArgs>
    {
        public EntityParentedCommandArgs Args { get; }
        private IEditorInterface EditorInterface { get; }

        public EntityParentedCommand(EntityParentedCommandArgs parameters, IEditorInterface editorInterface)
        {
            Args = parameters;
            EditorInterface = editorInterface;
        }

        public void Execute()
        {
            EditorInterface.EditorEntityManager.AddChild(Args.Parent, Args.Child);
        }
    }
}