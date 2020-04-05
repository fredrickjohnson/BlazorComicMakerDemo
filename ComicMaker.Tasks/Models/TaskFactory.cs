using System;

namespace ComicMaker.Tasks.Models
{
    public static class TaskFactory
    {
        public static ITask Create(string text, Action action)
        {
            return new SimpleTask(text, action);
        }
    }
}