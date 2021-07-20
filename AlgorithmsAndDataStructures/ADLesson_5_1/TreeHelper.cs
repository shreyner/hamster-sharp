using System;
using System.Collections.Generic;

namespace ADLesson_5_1
{
    public static class TreeHelper
    {
        /// <summary>
        ///     Поиск по дереву в ширину (BFS) на основе очереди
        /// </summary>
        public static TreeNode? BFSFindByValue(TreeNode rootNode, int value)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(rootNode);

            while (q.Count != 0)
            {
                var treeNode = q.Dequeue();
                Console.WriteLine($"Достаем из очереди элемент: {treeNode.Value}");

                if (treeNode.Value == value)
                {
                    Console.WriteLine($"Найден элемент: {treeNode.Value}");
                    return treeNode;
                }

                if (treeNode.LeftChild != null)
                {
                    Console.WriteLine($"Кладём в очередь левый элемент дерева: {treeNode.LeftChild.Value}");
                    q.Enqueue(treeNode.LeftChild);
                }

                if (treeNode.RightChild != null)
                {
                    Console.WriteLine($"Кладём в очередь правый элемент дерева: {treeNode.RightChild.Value}");
                    q.Enqueue(treeNode.RightChild);
                }
            }

            return null;
        }

        /// <summary>
        ///     Поиск по дереву в глубину (DFS) на основе стэка
        /// </summary>
        public static TreeNode? DFSFindByValue(TreeNode rootNode, int value)
        {
            var q = new Stack<TreeNode>();
            q.Push(rootNode);

            while (q.Count != 0)
            {
                var treeNode = q.Pop();
                Console.WriteLine($"Достаем из стэк элемент: {treeNode.Value}");

                if (treeNode.Value == value)
                {
                    Console.WriteLine($"Найден элемент: {treeNode.Value}");
                    return treeNode;
                }

                if (treeNode.LeftChild != null)
                {
                    Console.WriteLine($"Кладём в стэк левый элемент дерева: {treeNode.LeftChild.Value}");
                    q.Push(treeNode.LeftChild);
                }

                if (treeNode.RightChild != null)
                {
                    Console.WriteLine($"Кладём в стэк правый элемент дерева: {treeNode.RightChild.Value}");
                    q.Push(treeNode.RightChild);
                }
            }

            return null;
        }
    }
}