using BinarySearchTree;
using BinarySearchTree.Comparer;
using BinarySearchTree.Counter;
using BinarySearchTree.Iterator;
using BinarySearchTree.Model;
using BinarySearchTree.Searcher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private BST<IntegerNode> BST;
        public Form1()
        {
            InitializeComponent();
            InitData();
            ShowData(BST);
        }

        private void InitData()
        {
            int[] a = { 35, 10, 5, 20, 15, 40, 50 };
            List<IntegerNode> nodes = new List<IntegerNode>();
            for (int i = 0; i < a.Length; i++)
            {
                nodes.Add(new IntegerNode(a[i]));
            }
            BST = new BST<IntegerNode>(nodes, new IntegerComparer());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int val = int.Parse(tbDel.Text);
            BST.Delete(new IntegerNode(val));
            ShowData(BST);
        }

        private void ShowData(BST<IntegerNode> bst)
        {
            ArrayForwardIterator<IntegerNode> iterator =
                (ArrayForwardIterator<IntegerNode>)bst.InOrderTraversing(new ArrayForwardIteratorBounding<IntegerNode>());
            ArrayForwardIterator<IntegerNode> iterator2 =
                (ArrayForwardIterator<IntegerNode>)bst.PreOrderTraversing(new ArrayForwardIteratorBounding<IntegerNode>());
            ArrayForwardIterator<IntegerNode> iterator3 =
                (ArrayForwardIterator<IntegerNode>)bst.PostOrderTraversing(new ArrayForwardIteratorBounding<IntegerNode>());
            string s = "";
            string s2 = "";
            string s3 = "";
            for (iterator.First(); !iterator.IsDone(); iterator.Next())
                s += iterator.Current().GetValue().ToString() + " ";
            for (iterator2.First(); !iterator2.IsDone(); iterator2.Next())
                s2 += iterator2.Current().GetValue().ToString() + " ";
            for (iterator3.First(); !iterator3.IsDone(); iterator3.Next())
                s3 += iterator3.Current().GetValue().ToString() + " ";
            // Height
            string h = BST.GetHeight().ToString();
            // Count node
            string nodes = BST.CountNodeSatisfy(new NodeTotalCounter<IntegerNode>()).ToString();
            // Count node in each floor
            List<int> floor = BST.CountNodeInEachFloor();
            string nodeFs = "";
            if (floor != null)
            {
                foreach (int item in floor)
                {
                    nodeFs += item.ToString() + "\n";
                }
            }

            string res1 = new StringBuilder().Append("\n")
                        .Append(s).Append("\n\n")
                        .Append(s2).Append("\n\n")
                        .Append(s3).Append("\n\n")
                        .Append("Height = ").Append(h).Append("\n\n")
                        .Append("Nodes = ").Append(nodes).Append("\n\n")
                        .Append("NodesEachFloor:\n").Append(nodeFs).Append("\n")
                        .ToString();
            rtb1.Text = res1;


            // Count leaf nodes
            string leafs = BST.CountNodeSatisfy(new LeafCounter<IntegerNode>()).ToString();
            // Count node has 1 child
            string node1Child = BST.CountNodeSatisfy(new NodeHasOneChildCounter<IntegerNode>()).ToString();
            // Count node has left child only
            string nodeLeftChild = BST.CountNodeSatisfy(new NodeHasLeftChildOnlyCounter<IntegerNode>()).ToString();
            // Count node has right child only
            string nodeRightChild = BST.CountNodeSatisfy(new NodeHasRightChildOnlyCounter<IntegerNode>()).ToString();
            // Count node has full childs
            string nodeFullChilds = BST.CountNodeSatisfy(new NodeFullChildsCounter<IntegerNode>()).ToString();
            string res2 = new StringBuilder().Append("\n")
                          .Append("leafs = ").Append(leafs).Append("\n\n")
                          .Append("node1child = ").Append(node1Child).Append("\n\n")
                          .Append("node left child = ").Append(nodeLeftChild).Append("\n\n")
                          .Append("node right child = ").Append(nodeRightChild).Append("\n\n")
                          .Append("node full childs = ").Append(nodeFullChilds)
                          .ToString();
            rtb2.Text = res2;


            // Search max node value
            Node<IntegerNode> node1 = BST.SearchNodeSatisfy(new NodeMaxSearcher<IntegerNode>());
            string maxNode = GetValue(node1);
            // Search min node value
            Node<IntegerNode> node2 = BST.SearchNodeSatisfy(new NodeMinSearcher<IntegerNode>());
            string minNode = GetValue(node2);
            // Search max node value in left child
            Node<IntegerNode> node3 = BST.SearchNodeSatisfy(new NodeMaxInLeftChildSearcher<IntegerNode>());
            string maxNodeInLeft = GetValue(node3);
            // Search min node value in right child
            Node<IntegerNode> node4 = BST.SearchNodeSatisfy(new NodeMinInRightChildSearcher<IntegerNode>());
            string minNodeInRight = GetValue(node4);
            string res3 = new StringBuilder().Append("\n")
                          .Append("Max = ").Append(maxNode).Append("\n\n")
                          .Append("Min = ").Append(minNode).Append("\n\n")
                          .Append("Max in left = ").Append(maxNodeInLeft).Append("\n\n")
                          .Append("Min in right = ").Append(minNodeInRight).Append("\n\n")
                          .ToString();
            rtb3.Text = res3;
        }

        private string GetValue(Node<IntegerNode> node)
        {
            if (node == null || node.IsEmpty())
                return "empty";
            return ((ValuableNode<IntegerNode>)node).Value.GetValue().ToString();
        }

        private void btnGetPathLength_Click(object sender, EventArgs e)
        {
            int val = int.Parse(tbNodeValue.Text);
            int length = BST.GetPathLengthToNodeValue(new IntegerNode(val));
            MessageBox.Show("Length to " + val.ToString() + " = " + length.ToString());
        }

        private void btnGetPathLength_Click_1(object sender, EventArgs e)
        {
            int val = int.Parse(tbNodeValue.Text);
            string lenght = BST.GetPathLengthToNodeValue(new IntegerNode(val)).ToString();
            MessageBox.Show("Path lenght = " + lenght);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitData();
            ShowData(BST);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowData(BST);
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            int val = int.Parse(tbDel.Text);
            BST.Delete(new IntegerNode(val));
            ShowData(BST);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int val = int.Parse(tbInsert.Text);
            bool res = BST.Insert(new IntegerNode(val));
            ShowData(BST);
            string s = res ? "Insert successful" : "Cannot insert";
            MessageBox.Show(s);
        }

        private void btnSearchNodeValue_Click(object sender, EventArgs e)
        {
            int val = int.Parse(tbSearchNode.Text);
            Node<IntegerNode> node = BST.SearchNodeValue(new IntegerNode(val));
            string s = "";
            s += "  - Parent = " + GetValue(node.Parent) + "\n";
            if (!node.IsEmpty())
            {
                ValuableNode<IntegerNode> valNode = (ValuableNode<IntegerNode>)node;
                s += "  - Left = " + GetValue(valNode.Left) + "\n";
                s += "  - Right = " + GetValue(valNode.Right);
            }
            MessageBox.Show("Node = " + GetValue(node) + "\n" + s);
        }
    }
}
