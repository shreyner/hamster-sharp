using System;

namespace ADLesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            tree.AddItem(50);
            tree.AddItem(70);
            tree.AddItem(60);
            tree.AddItem(51);
            tree.AddItem(10);
            tree.AddItem(5);
            tree.AddItem(6);
            tree.GetRoot();

            Console.WriteLine(TreeHelper.GetTreeInLine(tree));
            
            tree.RemoveItem(70);
            tree.GetRoot();

            Console.WriteLine(TreeHelper.GetTreeInLine(tree));

            var node = tree.GetNodeByValue(51);
            tree.GetRoot();
            
            Console.WriteLine(node);
        }
    }
}