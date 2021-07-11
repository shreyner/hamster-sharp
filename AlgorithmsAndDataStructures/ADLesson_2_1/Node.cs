using System;
using System.Collections.Generic;
using System.Linq;

namespace ADLesson_2_1
{
    public class Node
    {
        public int Value { get; set; }
        public Node? PrevNode { get; set; }
        public Node? NextNode { get; set; }
    }

    /// <summary>
    ///     Утилитный класс для тестирования Linked Node
    /// </summary>
    public static class NodeUtilTesting
    {
        /// <summary>
        ///     Функция возвращает строку из всех Value Node.
        ///     Функция двигается только в сторону nextNode.
        /// </summary>
        /// <example>
        ///     // Пример списка Node (10) -> Node (15) -> Node(20)
        ///     NodeUtilTesting.GetChainingValueFromFirstToLast(node) // 10,15,20
        /// </example>
        public static string GetChainingValueFromFirstToLast(Node node)
        {
            Node currentNode = node;
            var resultList = new List<int>();
            
            while (currentNode != null)
            {
                resultList.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            return string.Join(',', resultList);
        }
    }
}