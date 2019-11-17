using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement2._2
{
    public class TreeNode : IEnumerable
    {
        public int Data { get; set; }

        public TreeNode LeftNode { get; set; }

        public TreeNode RightNode { get; set; }

        public TreeNode(int value)
        {
            Data = value;
        }

        public void Insert(int value)
        {
            if (value < this.Data)
            {
                if (this.LeftNode == null)
                {
                    LeftNode = new TreeNode(value);
                }
                else
                {
                    LeftNode.Insert(value);
                }
            }
            else 
            {
                if (this.RightNode == null)
                {
                    RightNode = new TreeNode(value);
                }
                else
                {
                    RightNode.Insert(value);
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new PreOrderTraversalEnumerator(this);
        }

        private class PreOrderTraversalEnumerator : IEnumerator
        {
            TreeNode CurrentTreeNode;

            TreeNode Root;

            Stack<TreeNode> depthFirst = new Stack<TreeNode>();

            public PreOrderTraversalEnumerator(TreeNode treeNode)
            {
                Root = treeNode;
                CurrentTreeNode = treeNode;
                //depthFirst.Push(treeNode);
            }

            public object Current
            {
                get
                {
                    return CurrentTreeNode;
                }
            }
            public bool MoveNext()
            {
                //if the first time we call the movenext, stack is filled with root, and current becomes root
                if (depthFirst.Count == 0)
                {
                    depthFirst.Push(Root);
                    return true;
                }

                if (CurrentTreeNode.LeftNode != null)
                {
                    var originalNode = CurrentTreeNode;
                    CurrentTreeNode = CurrentTreeNode.LeftNode;
                    depthFirst.Push(CurrentTreeNode);
                    originalNode.LeftNode = null;
                    return true;
                }

                if (CurrentTreeNode.RightNode != null)
                {
                    var originalNode = CurrentTreeNode;
                    CurrentTreeNode = CurrentTreeNode.RightNode;
                    depthFirst.Push(CurrentTreeNode);
                    originalNode.RightNode = null;
                    return true;
                }

                //if the node doeasnt have a left child nor a right child:
                depthFirst.Pop();

                CurrentTreeNode = depthFirst.Peek();
                MoveNext();
                return true;
            }

            public void Reset()
            {
                CurrentTreeNode = Root;
            }
           
        }

        public override string ToString()
        {
            return $"{this.Data}";
        }
    }
}
