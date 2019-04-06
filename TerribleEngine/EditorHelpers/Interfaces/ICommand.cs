namespace TerribleEngine.EditorHelpers.Interfaces
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<TArgs> : ICommand
    {
        TArgs Args { get; }
    }
}