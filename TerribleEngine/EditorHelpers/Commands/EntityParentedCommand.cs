using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityParentedCommand : ICommand
    {
        public EntityParentedCommandParams Parameters { get; }
        private IEditorInterface EditorInterface { get; }

        public EntityParentedCommand(EntityParentedCommandParams parameters, IEditorInterface editorInterface)
        {
            Parameters = parameters;
            EditorInterface = editorInterface;
        }

        public void Execute()
        {
            EditorInterface.EditorEntityManager.AddChild(Parameters.Parent, Parameters.Child);
        }
    }
}