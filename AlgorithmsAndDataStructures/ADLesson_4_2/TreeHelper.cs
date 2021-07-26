using System.Collections.Generic;

namespace ADLesson_4_2
{
    public class NodeInfo
    {
        public int Depth = 0;
        public TreeNode Node;
    }

    public static class TreeHelper
    {
        /// <summary>
        ///     Поиск по дереву в ширину (BFS) на основе стэка
        /// </summary>
        public static TreeNode? BFSFindByValue(ITree tree, int value)
        {
            var _rootNode = tree.GetRoot();

            if (_rootNode == null)
            {
                return null;
            }

            var q = new Queue<TreeNode>();
            q.Enqueue(_rootNode);

            while (q.Count != 0)
            {
                var treeNode = q.Dequeue();

                if (treeNode.Value == value)
                {
                    return treeNode;
                }

                if (treeNode.LeftChild != null)
                {
                    q.Enqueue(treeNode.LeftChild);
                }

                if (treeNode.RightChild != null)
                {
                    q.Enqueue(treeNode.RightChild);
                }
            }

            return null;
        }

        /// <summary>
        ///     Поиск по дереву в глубину (DFS) на основе стэка
        /// </summary>
        public static TreeNode? DFSFindByValue(ITree tree, int value)
        {
            throw new System.NotImplementedException();
        }

        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var buffer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo {Node = tree.GetRoot()};
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    buffer.Enqueue(left);
                }

                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    buffer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }
}