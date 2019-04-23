using TerribleEngine.ECS;
using TerribleEngine.EditorHelpers.Commands;
using TerribleEngine.EditorHelpers.Interfaces;
using TerribleEngine.Events;

namespace TerribleEngine.EditorHelpers
{
    public class EngineInterface
    {
        public EventManager EventManager { get; }
        public IEditorInterface EditorInterface { get; set; }

        public EngineInterface(EventManager eventManager)
        {
            EventManager = eventManager;
        }

        public void RegisterEvents()
        {
            EventManager.RegisterEventListener<EntityCreatedEvent>(OnEntityAdded);
            EventManager.RegisterEventListener<EntityParentedEvent>(OnEntityParented);
        }

        public void RegisterEditor(IEditorInterface editorInterface)
        {
            EditorInterface = editorInterface;
        }

        private void SendCommand(ICommand command)
        {
            EditorInterface?.ReceiveCommand(command);
        }

        private void OnEntityAdded(EntityCreatedEvent args)
        {
            var command = new EntityCreatedCommand(new EntityCreatedCommandArgs(args.Entity), EditorInterface);
            SendCommand(command);
        }

        private void OnEntityParented(EntityParentedEvent args)
        {
            var command = new EntityParentedCommand(new EntityParentedCommandArgs(args.Parent, args.Child), EditorInterface);
            SendCommand(command);
        }
    }
}