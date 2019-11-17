using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement2._2
{
    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public void Insert(int data)
        {
            if (Root == null)
            {
                Root = new TreeNode(data);
            }
            else
            {
                Root.Insert(data);
            }
        }
        public IEnumerator PreOrderTraversal()
        {
            return Root.GetEnumerator();
        }
    }
}
