using System;
using System.Collections.Generic;

namespace TreeSort
{
    internal class TreeNode<T> where T : IComparable<T>
    {
        public T Item { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public int Insert(TreeNode<T> node)
        {
            var counter = 0;
            counter++;
            if (Comparer<T>.Default.Compare(node.Item, Item) < 0)
            {
                if (Left == null)
                    Left = node;
                else
                    counter += Left.Insert(node);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else
                    counter += Right.Insert(node);
            }

            return counter;
        }

        public T[] ToArray(List<T> elements = null)
        {
            if (elements == null) elements = new List<T>();

            Left?.ToArray(elements);

            elements.Add(Item);

            Right?.ToArray(elements);

            return elements.ToArray();
        }

        public static T[] GetSorted(IReadOnlyList<T> array, out int operationsCount)
        {
            var treeNode = new TreeNode<T>(array[0]);
            operationsCount = 0;
            for (var i = 1; i < array.Count; i++) operationsCount += treeNode.Insert(new TreeNode<T>(array[i]));

            return treeNode.ToArray();
        }
    }
}