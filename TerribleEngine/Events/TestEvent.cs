namespace TerribleEngine.Events
{
    public class TestEvent : IEvent
    {
        public string Name { get; }
        public string Message { get; }

        public TestEvent(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}