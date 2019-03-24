using TerribleEditorV2.Controller;
using TerribleEngine.EditorHelpers;
using TerribleEngine.EditorHelpers.Commands;
using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEditorV2.EngineHelpers
{
    public class EditorInterface : IEditorInterface
    {
        public IEditorEntityManager EditorEntityManager { get; }

        public EditorInterface(IEditorEntityManager editorEntityManager)
        {
            EditorEntityManager = editorEntityManager;
            TerribleEditor.TerribleApp.EngineInterface.RegisterEditor(this);

        }

        public void ReceiveCommand(ICommand command)
        {
            command.Execute();
        }
    }
}