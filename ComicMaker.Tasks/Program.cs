using System;
using ComicMaker.Tasks.Models;

namespace ComicMaker.Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var compositionTask = new CompositionTask();

            compositionTask.Execute();
            Console.WriteLine("Done....");
            Console.Read();
        }
    }
}
