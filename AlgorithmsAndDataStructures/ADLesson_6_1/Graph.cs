using System;
using System.Collections.Generic;
using System.Linq;

namespace ADLesson_6_1
{
    public class GraphHelpers
    {
        /// <summary>
        ///     Реализация алгоритма Дэекстры с построением дерева кратчашего пути от одной верины до всех остальных.
        ///
        ///     Обход дерева в ширину на основе очереди
        /// </summary>
        public static void Dijkstra(int[,] graph)
        {
            var widthGraph = graph.GetLength(0); // Количество вершин в графе
            var q = new Queue<int>();
            var a = new int[widthGraph]; // Храним вес до вершины [MaxValue, 0, 3, 2, MaxValue]
            var route = new int[widthGraph]; // Храним путь до вершины пример [index - текущая вершина: value - родительская вершина]
            Array.Fill(a, Int32.MaxValue);

            q.Enqueue(0);
            a[0] = 0;
            route[0] = 0;

            while (q.Count != 0)
            {
                var currentGraphIndex = q.Dequeue();
                var currentSum = a[currentGraphIndex];

                for (int columnIndex = 0; columnIndex < widthGraph; columnIndex++)
                {
                    var currentWidth = graph[currentGraphIndex, columnIndex];

                    if (currentWidth is Int32.MaxValue) continue;

                    if (currentSum + currentWidth < a[columnIndex])
                    {
                        a[columnIndex] = currentSum + currentWidth; // Вес
                        route[columnIndex] = currentGraphIndex; // Откуда пришли сюда
                        q.Enqueue(columnIndex);
                    }
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", a.Select((width, index) => $"[Родитель: {route[index] + 1}, Вершина:{index + 1}, Длина пути: {width}]")));
        }
        
        /// Практиковался обхощить граф
        
        /// <summary>
        ///     Обход графа в ширину (BFS) на основе очереди
        /// </summary>
        public static void bfs(int[,] graph)
        {
            var ostov = new int[graph.GetLength(0)];
            var widthGraph = graph.GetLength(0);
            var q = new Queue<int>();

            q.Enqueue(0);
            ostov[0] = 1;

            while (q.Count != 0)
            {
                var startIndex = q.Dequeue();
                for (int columnIndex = 0; columnIndex < widthGraph; columnIndex++)
                {
                    var currentItem = graph[startIndex, columnIndex];

                    if (currentItem is Int32.MaxValue or 0)
                    {
                        continue;
                    }

                    var isHas = ostov[columnIndex];

                    if (isHas is not 0)
                    {
                        continue;
                    }

                    q.Enqueue(columnIndex);
                    ostov[columnIndex] = 1;
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", ostov));
        }

        /// <summary>
        ///     Обход графа в глубину (DFS) на основе стэка
        /// </summary>
        public static void dfs(int[,] graph)
        {
            var ostov = new int[graph.GetLength(0)];
            var widthGraph = graph.GetLength(0);
            var q = new Stack<int>();

            q.Push(0);
            ostov[0] = 1;

            while (q.Count != 0)
            {
                var startIndex = q.Pop();
                for (int columnIndex = 0; columnIndex < widthGraph; columnIndex++)
                {
                    var currentItem = graph[startIndex, columnIndex];

                    if (currentItem is Int32.MaxValue or 0)
                    {
                        continue;
                    }

                    var isHas = ostov[columnIndex];

                    if (isHas is not 0)
                    {
                        continue;
                    }

                    q.Push(columnIndex);
                    ostov[columnIndex] = 1;
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", ostov));
        }
    }
}