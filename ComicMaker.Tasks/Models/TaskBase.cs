namespace ComicMaker.Tasks.Models
{
    public abstract class TaskBase : ITask
    {
        public abstract string Name { get; }
        public abstract void Execute();
    }
}