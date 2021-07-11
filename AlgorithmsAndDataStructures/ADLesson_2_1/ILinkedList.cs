namespace ADLesson_2_1
{
    /// <summary>
    ///     Двухсвязный список 
    /// </summary>
    public interface ILinkedList
    {
        /// <summary>
        ///     Возвращает количество элементов в списке
        /// </summary>
        int GetCount();

        /// <summary>
        ///     Возвращает первый элемент списка
        /// </summary>
        Node GetList();
        
        /// <summary>
        ///     Добавляет новый элемент списка
        /// </summary>
        void AddNode(int value);
        
        /// <summary>
        ///     Добавляет новый элемент списка после определённого элемента
        /// </summary>
        void AddNodeAfter(Node node, int value);
        
        /// <summary>
        ///     Удаляет элемент по порядковому номеру
        /// </summary>
        void RemoveNode(int index);
        
        /// <summary>
        ///     Удаляет указанный элемент
        /// </summary>
        void RemoveNode(Node node);
        
        /// <summary>
        ///     Ищет элемент по его значению
        /// </summary>
        Node FindNode(int searchValue); 
    }
}