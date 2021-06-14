using System;

namespace Lesson_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new char[10, 10]
            {
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'X', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'X', 'X', 'X', 'X', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'X', 'X'},
                {'O', 'O', 'X', 'O', 'O', 'X', 'O', 'O', 'O', 'O'},
                {'X', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'X', 'O', 'O', 'O', 'X', 'X', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'X', 'X', 'O', 'O', 'X', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
            };

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write($"{board[row, column]} ");
                }

                Console.Write("\n");
            }
        }
    }
}