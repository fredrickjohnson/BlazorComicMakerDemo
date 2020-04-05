namespace ComicMaker.Tasks.Models
{
    public interface ITask
    {
        string Name { get; }
        void Execute();
    }
}