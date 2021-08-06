using System;

namespace ADLesson_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ссылка на картику с графом
            // https://d2xzmw6cctk25h.cloudfront.net/asset/3173051/attachment/b5fb6fa25f151cf55da3aa6166499e53.png

            var inputGraph = new[,]
            {
                {0, 32, 95, 75, 57, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue},
                {32, 0, 5, Int32.MaxValue, 23, Int32.MaxValue, Int32.MaxValue, 16},
                {95, 5, 0, 18, Int32.MaxValue, 6, Int32.MaxValue, Int32.MaxValue},
                {75, Int32.MaxValue, 18, 0, 24, 9, Int32.MaxValue, Int32.MaxValue},
                {57, 23, Int32.MaxValue, 24, 0, 11, 20, 94},
                {Int32.MaxValue, Int32.MaxValue, 6, 9, 11, 0, 7, Int32.MaxValue},
                {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 20, 7, 0, 81},
                {Int32.MaxValue, 16, Int32.MaxValue, Int32.MaxValue, 94, Int32.MaxValue, 81, 0},
            };

            // Поиск наименьшего основного дерева по алгоритму Дэйксторы
            GraphHelpers.Dijkstra(inputGraph);
        }
    }
}