using System;

namespace ComicMaker.Tasks.Models
{
    public class SimpleTask : TaskBase
    {
        private readonly Action _action;

        public override string Name { get; }
        public override void Execute()
        {
            _action();
        }

        public SimpleTask(string text, Action action)
        {
            Name = text;
            _action = action;
        }
    }
}