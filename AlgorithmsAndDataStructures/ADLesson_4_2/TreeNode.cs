using System.Collections.Generic;

namespace ADLesson_4_2
{
    public class TreeNode
    {
        public int Value;
        public TreeNode? ParentNode, LeftChild, RightChild;

        public override bool Equals(object? obj)
        {
            return obj != null && ((TreeNode) obj).Value == this.Value;
        }
    }
}