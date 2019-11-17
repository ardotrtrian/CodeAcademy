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
            }

            public object Current
            {
                get
                {
                    return CurrentTreeNode;
                }
            }

            //Start with root node and push on to stack s
            //While stack is not empty
            // - Pop from stack current = s.pop() and process the node.
            // - Push current.right onto to stack.
            // - Push current.left onto to stack.

            public bool MoveNext()
            {
                //first time calling the MoveNext method
                if (depthFirst.Count == 0)
                {
                    depthFirst.Push(Root);
                    return true;
                }

                if (depthFirst != null)
                {
                    //pop the node from stack and process it
                    depthFirst.Pop();

                    //push right child first if it exists
                    if (CurrentTreeNode.RightNode != null)
                    {
                        depthFirst.Push(CurrentTreeNode.RightNode);
                    }
                    //then push left child,because left child must beprocessed first in preorder traversal
                    if (CurrentTreeNode.LeftNode != null)
                    {
                        depthFirst.Push(CurrentTreeNode.LeftNode);
                    }
                    //when stack is full
                    if (depthFirst.Count != 0)
                    {
                        //peek node in stack is the node to print next
                        CurrentTreeNode = depthFirst.Peek();
                    }
                    else
                    {
                        //stack has become empty means all nodes has been printed and iteration is over
                        return false;
                    }
                    //there is still elements to iterate through
                    return true;
                }
                //---------
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
