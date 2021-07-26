namespace ADLesson_4_2
{
    public interface ITree
    {
        TreeNode? GetRoot();

        /// <summary>
        ///     Добавляет узел
        /// </summary>
        void AddItem(int value);

        /// <summary>
        ///     Удаляет узел по значению
        /// </summary>
        void RemoveItem(int value);

        /// <summary>
        ///     Получить узел по значению
        /// </summary>
        TreeNode? GetNodeByValue(int value);

        /// <summary>
        ///     Нарисовать дерево в консиоли 
        /// </summary>
        void PrintTree();
    }
}