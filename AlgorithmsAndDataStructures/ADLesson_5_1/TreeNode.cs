namespace ADLesson_5_1
{
    public class TreeNode
    {
        public int Value;
        public TreeNode? LeftChild, RightChild;

        public override bool Equals(object? obj)
        {
            return obj != null && ((TreeNode) obj).Value == this.Value;
        }
    }
}