using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TreeSort
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Команды:\r\n1.Run Experiments\r\n2.Sort strings from keyboard\r\n3.Exit\r\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        WriteToFile(RunExperiments("experiments.xml"));
                        break;

                    case "2":
                        Console.WriteLine(
                            "Вводите строки с клавиатуры через Enter, для окончания ввода введите пустую строку");
                        var input = new List<string>();
                        var str = Console.ReadLine();
                        while (str != "")
                        {
                            input.Add(str);
                            str = Console.ReadLine();
                        }

                        foreach (var item in TreeNode<string>.GetSorted(input, out _)) Console.WriteLine(item);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }
            }
        }

        private static IEnumerable<string> RunExperiments(string filename)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var arrays = XmlReader.ReadExperiments(filename);
            var result = new List<string>();
            foreach (var arr in arrays)
            {
                TreeNode<string>.GetSorted(arr, out var count);
                Console.WriteLine($"Length {arr.Count}, Operations Count {count}");
                result.Add($"{arr.Count} {count}");
            }

            stopwatch.Stop();
            Console.WriteLine("Потрачено времени на выполнение: " + stopwatch.Elapsed);
            return result;
        }

        private static void WriteToFile(IEnumerable<string> input)
        {
            var path = $"{Directory.GetCurrentDirectory()}\\result.txt";
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (var item in input) sw.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}