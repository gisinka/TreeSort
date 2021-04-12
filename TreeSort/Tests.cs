using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TreeSort
{
    [TestFixture]
    internal class Tests
    {
        [TestCase(100, 0, 1, 15)]
        [TestCase(100, 0, 2, 15)]
        [TestCase(100, 0, 10, 15)]
        [TestCase(10000, 0, 10000, 15)]
        [TestCase(100000, 0, 100000, 15)]
        public static void RandomArraysSortTest(int length, int minNumber, int maxNumber, int repeats)
        {
            for (var i = 0; i < repeats; i++)
            {
                var toSort = RandomArrayGenerator(length, minNumber, maxNumber);
                var treeSorted = TreeNode<int>.GetSorted(toSort, out _);
                var internalSorted = toSort.ToArray();
                Array.Sort(internalSorted);
                Assert.AreEqual(internalSorted, treeSorted);
            }
        }

        public static int[] RandomArrayGenerator(int length, int minNumber, int maxNumber)
        {
            var random = new Random();
            var generated = new List<int>();
            for (var i = 0; i < length; i++)
                generated.Add(random.Next(minNumber, maxNumber));
            return generated.ToArray();
        }
    }
}