using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TreeSort
{
    internal class XmlReader
    {
        public static List<List<string>> ReadExperiments(string filename)
        {
            var result = new List<List<string>>();
            var xml = XDocument.Load(filename);
            foreach (var node in xml.Descendants("node"))
            {
                var min = int.Parse(node.Attribute("minElement").Value);
                var max = int.Parse(node.Attribute("maxElement").Value);
                var minLen = int.Parse(node.Attribute("startLength").Value);
                var maxLen = int.Parse(node.Attribute("maxLength").Value);
                var repeat = int.Parse(node.Attribute("repeat").Value);
                switch (node.Attribute("name").Value)
                {
                    case "Arithmetic Progression":
                    {
                        var diff = int.Parse(node.Attribute("diff").Value);
                        result.AddRange(CreateArithmeticProgression(min, max, minLen, maxLen, diff, repeat));
                        break;
                    }
                    case "Geometric Progression":
                    {
                        var mult = double.Parse(node.Attribute("mult").Value);
                        result.AddRange(CreateGeometricProgression(min, max, minLen, maxLen,
                            mult, repeat));
                        break;
                    }
                }
            }

            return result;
        }

        private static List<List<string>> CreateArithmeticProgression(int min = 0, int max = 0, int minLength = 0,
            int maxLength = 0, int diff = 0, int repeat = 0)
        {
            var result = new List<List<string>>();
            var random = new Random();
            for (var i = minLength; i <= maxLength; i += diff)
            for (var j = 0; j < repeat; j++)
            {
                var newList = new List<string>();
                for (var k = 0; k < i; k++) newList.Add(random.Next(min, max).ToString());
                result.Add(newList);
            }

            return result;
        }

        private static List<List<string>> CreateGeometricProgression(int min = 0, int max = 0, int minLength = 0,
            int maxLength = 0, double mult = 0, int repeat = 0)
        {
            var result = new List<List<string>>();
            var random = new Random();
            for (var i = minLength; i <= maxLength; i = (int) (i * mult))
            for (var j = 0; j < repeat; j++)
            {
                var newList = new List<string>();
                for (var k = 0; k < i; k++) newList.Add(random.Next(min, max).ToString());
                result.Add(newList);
            }

            return result;
        }
    }
}