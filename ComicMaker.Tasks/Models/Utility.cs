using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUI;

namespace ComicMaker.Tasks.Models
{
    public static class Utility
    {
        public static void ShowOptions(string title, IEnumerable<ITask> tasks)
        {
            Console.Clear();
            new ConsoleMenu<ITask>(title, tasks.Select(x => new ConsoleMenuItem<ITask>(x.Name, y => y.Execute(), x))).RunConsoleMenu();
        }

        public static bool Confirm(string text)
        {
            var results = false;
            var menu = new ConsoleMenu<bool>(text, new List<ConsoleMenuItem<bool>>
            {
                new ConsoleMenuItem<bool>("No", (value) => results = value,false),
                new ConsoleMenuItem<bool>("Yes", (value) => results = value,true)
            });
            menu.RunConsoleMenu();
            return results;
        }

        private static string ReadLine()
        {
            var result = Console.ReadLine();
            return (result != null) ? result.Trim() : string.Empty;
        }

        public static string GetString(string text)
        {
            Console.WriteLine(text);
            return ReadLine();
        }

        public static int GetInt(string text)
        {
            Console.WriteLine(text);
            return int.Parse(ReadLine() ?? throw new InvalidOperationException());
        }

        public static double GetDouble(string text)
        {
            Console.WriteLine(text);
            return double.Parse(ReadLine() ?? throw new InvalidOperationException());
        }

        public static void Title(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine("");
        }

        public static void TitleWithoutClear(string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("");
        }

        /*

        public static void PrintAndWait(ErrorResult result)
        {
            TitleWithoutClear("Errors...");
            foreach (var x in result.Errors)
            {
                if (string.IsNullOrEmpty(x.Name))
                {
                    Console.WriteLine(x.Text);
                }
                else
                {
                    Console.WriteLine(x.Name + @":" + x.Text);
                }
            }
            Console.Read();
        }*/

        public static void PrintAndWait(string text)
        {
            Console.WriteLine(text);
            Console.Read();
        }
    }
}