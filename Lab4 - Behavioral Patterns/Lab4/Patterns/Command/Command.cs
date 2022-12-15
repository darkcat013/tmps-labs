namespace Lab4.Patterns.Command
{
    public abstract class Command
    {
        public bool IsExecuted { get; set; }

        public abstract void Execute();
    }
}
