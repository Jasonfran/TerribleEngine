using TerribleEngine.ECS;
using TerribleEngine.EditorHelpers.Commands;
using TerribleEngine.EditorHelpers.Interfaces;
using TerribleEngine.Events;
using TerribleEngine.Scene;

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

        private void OnEntityAdded(object args)
        {
            if (args is EntityCreatedEvent eventArgs)
            {
                var command =
                    new EntityCreatedCommand(new EntityCreatedCommandParams(eventArgs.Entity), EditorInterface);
                SendCommand(command);
            }
        }

        private void OnEntityParented(object args)
        {
            if (args is EntityParentedEvent eventArgs)
            {
                var command = new EntityParentedCommand(new EntityParentedCommandParams(eventArgs.Parent, eventArgs.Child), EditorInterface);
                SendCommand(command);
            }
        }
    }
}