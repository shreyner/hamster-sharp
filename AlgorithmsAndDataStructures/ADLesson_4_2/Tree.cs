using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace ADLesson_4_2
{
    public class Tree : ITree
    {
        private TreeNode? _rootNode;

        public TreeNode? GetRoot()
        {
            return _rootNode;
        }

        public void AddItem(int value)
        {
            if (_rootNode == null)
            {
                _rootNode = new TreeNode {Value = value};
                return;
            }

            var currentNode = _rootNode;

            while (currentNode != null)
            {
                if (value < currentNode.Value)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;
                    }

                    currentNode.LeftChild = new TreeNode {Value = value, ParentNode = currentNode};
                    break;
                }

                if (value > currentNode.Value)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;
                    }

                    currentNode.RightChild = new TreeNode {Value = value, ParentNode = currentNode};
                    break;
                }
            }
        }


        public void RemoveItem(int value)
        {
            var treeNode = TreeHelper.BFSFindByValue(this, value);

            if (treeNode == null)
            {
                throw new System.AggregateException($"Element {value} not found");
            }

            if (treeNode.ParentNode?.LeftChild?.Equals(treeNode) is not null or false)
            {
                treeNode.ParentNode.LeftChild = null;
                return;
            }

            if (treeNode.ParentNode?.RightChild?.Equals(treeNode) is not null or false)
            {
                treeNode.ParentNode.RightChild = null;
            }
        }

        public TreeNode? GetNodeByValue(int value)
        {
            return TreeHelper.BFSFindByValue(this, value);
        }

        public void PrintTree()
        {
            var treeInLine = TreeHelper.GetTreeInLine(this);

            throw new System.NotImplementedException();
        }
    }
}