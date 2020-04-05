using System.Collections.Generic;

namespace ComicMaker.Tasks.Models
{
    public class CompositionTask : TaskBase
    {
        private readonly IList<ITask> _tasks = new List<ITask>();

        public CompositionTask Add(ITask task)
        {
            _tasks.Add(task);
            return this;
        }

        public override void Execute()
        {
            foreach (var task in _tasks)
                task.Execute();
        }
    }
}