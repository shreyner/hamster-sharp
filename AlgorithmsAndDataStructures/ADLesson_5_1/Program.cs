using System;

namespace ADLesson_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *              (50)
             *      (30)            (70)
             *  (20)    (25)    (60)    (65)
             * 
             */
            var rootNode = new TreeNode {Value = 50};
            rootNode.LeftChild = new TreeNode {Value = 30};
            rootNode.LeftChild.LeftChild = new TreeNode {Value = 20};
            rootNode.LeftChild.RightChild = new TreeNode {Value = 25};

            rootNode.RightChild = new TreeNode {Value = 70};
            rootNode.RightChild.LeftChild = new TreeNode {Value = 60};
            rootNode.RightChild.RightChild = new TreeNode {Value = 65};

            Console.WriteLine("Поиск в ширину на очереди");
            var result =  TreeHelper.BFSFindByValue(rootNode, 60);
            Console.WriteLine($"Result: {result?.Value}");
            
            Console.WriteLine("==========================================");

            Console.WriteLine("Поиск в глубину на основе стэка");
            var result2 =  TreeHelper.DFSFindByValue(rootNode, 60);
            Console.WriteLine($"Result: {result?.Value}");
        }
    }
}