using System;

namespace ADLesson_2_1
{
    public class GLinkedList : ILinkedList
    {
        private int _count = 0;
        private Node? _head;
        private Node? _last;

        public int GetCount()
        {
            return this._count;
        }

        public Node GetList()
        {
            return _head;
        }

        public void AddNode(int value)
        {
            Node? node;
            if (_head == null)
            {
                node = new Node {Value = value};
                _head = node;
                _last = node;
                _count += 1;
                return;
            }

            node = new Node {Value = value, PrevNode = _last};
            _last.NextNode = node;
            _last = node;
            _count += 1;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node {Value = value};

            var nextNode = node.NextNode;

            if (nextNode != null)
            {
                nextNode.PrevNode = newNode;
                newNode.NextNode = nextNode;
            }

            node.NextNode = newNode;
            newNode.PrevNode = node;
            _count += 1;
        }

        public void RemoveNode(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must not be less than 0", nameof(index));
            }

            if (index + 1 > _count)
            {
                throw new ArgumentException("Index cannot be more count", nameof(index));
            }

            Node currentNode =
                GetList() ?? throw new ArgumentException("Internal error"); // TODO: Нормально описание ошибки

            for (int i = 0; i < index; i++)
            {
                currentNode =
                    currentNode.NextNode ??
                    throw new ArgumentException("Internal error"); // TODO: Нормальное описание ошибки
            }


            RemoveNode(currentNode);
        }

        public void RemoveNode(Node node)
        {
            Node? prevCurrentNode = node.PrevNode;
            Node? nextCurrentNode = node.NextNode;
            node.PrevNode = null;
            node.NextNode = null;


            if (prevCurrentNode != null && nextCurrentNode != null)
            {
                prevCurrentNode.NextNode = nextCurrentNode;
                nextCurrentNode.PrevNode = prevCurrentNode;
            }

            if (prevCurrentNode != null && nextCurrentNode == null)
            {
                prevCurrentNode.NextNode = null;
                _last = prevCurrentNode;
            }

            if (nextCurrentNode != null && prevCurrentNode == null)
            {
                nextCurrentNode.PrevNode = null;
                _head = nextCurrentNode;
            }

            _count -= 1;
        }

        public Node? FindNode(int searchValue)
        {
            var node = GetList();

            while (node != null)
            {
                if (node.Value == searchValue)
                {
                    return node;
                }

                node = node.NextNode;
            }

            return node;
        }
    }
}