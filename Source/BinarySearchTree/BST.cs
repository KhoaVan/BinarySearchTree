using System.Collections.Generic;
using BinarySearchTree.Iterator;
using BinarySearchTree.Comparer;
using BinarySearchTree.Searcher;
using BinarySearchTree.Counter;
using BinarySearchTree.Model;
/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree
{
    public class BST<T> where T : INodeValue
    {
        public Node<T> RootNode { get; private set; }
        private ICComparer<T> _comparer;
        public BST(ICComparer<T> comparer) 
        {
            _comparer = comparer;
            RootNode = new EmptyNode<T>();
        }
        public BST(T[] data, ICComparer<T> comparer) 
        {
            _comparer = comparer;
            RootNode = new EmptyNode<T>();
            if (data != null)
            {
                foreach (var value in data)
                {
                    this.Insert(value);
                }
            }
        }
        public BST(List<T> data, ICComparer<T> comparer)
        {
            _comparer = comparer;
            RootNode = new EmptyNode<T>();
            if (data != null)
            {
                foreach (var value in data)
                {
                    this.Insert(value);
                }
            }
        }
        /// <summary>
        /// Verify if BSTree is empty
        /// </summary>
        public bool IsEmpty()
        {
            return RootNode.IsEmpty();
        }
        public void Clear()
        {
            RootNode = null;
            RootNode = new EmptyNode<T>();
        }
        /// <summary>
        /// Insert value into BSTTree
        /// </summary>
        /// <param name="value"></param>
        public bool Insert(T value)
        {
            if (RootNode.IsEmpty())
            {
                RootNode = new ValuableNode<T>(value);
                return true;
            }
            else
                return ((ValuableNode<T>)RootNode).Insert(value, _comparer);
        }
        /// <summary>
        /// Delete a node with specific value
        /// </summary>
        /// <param name="value">Node value</param>
        public void Delete(T value)
        {
            // Root is empty
            if (RootNode.IsEmpty())
                return;
            // Root is the victim
            ValuableNode<T> valRoot = (ValuableNode<T>)RootNode;
            if ((_comparer.Compare(value, valRoot.Value) == 0) && !valRoot.IsFullChilds())
            {
                if (valRoot.IsSingle())
                {
                    RootNode = new EmptyNode<T>();
                }
                else if (valRoot.IsLeftEmptyOnly())
                {
                    RootNode = valRoot.Right;
                    RootNode.Parent = new EmptyNode<T>();
                    ((ValuableNode<T>)valRoot.Right).IsChanged = true; //
                }
                else
                {
                    RootNode = valRoot.Left;
                    RootNode.Parent = new EmptyNode<T>();
                    ((ValuableNode<T>)valRoot.Left).IsChanged = true; //
                }

                valRoot = null;
                return;
            }
            
            valRoot.Delete(value, _comparer);
        }

        /// <summary>
        /// Left - Node - Right traversal
        /// </summary>
        /// <param name="boundingIterator"></param>
        /// <returns></returns>
        public IIterator<T> InOrderTraversing(IIteratorBounding<T> boundingIterator)
        {
            InOrderTraversing(RootNode, boundingIterator);
            return boundingIterator.GetIterator();
        }

        private void InOrderTraversing(Node<T> root, IIteratorBounding<T> boundingIterator)
        {
            if (root.IsEmpty())
                return;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            InOrderTraversing(valNode.Left, boundingIterator); // Traversing the left BSTree

            boundingIterator.Add(valNode.Value); // Add value to bounding iterator

            InOrderTraversing(valNode.Right, boundingIterator); // Traversing the right BSTree
        }
        /// <summary>
        /// Node - Left - Right traversal
        /// </summary>
        /// <param name="boundingIterator"></param>
        /// <returns></returns>
        public IIterator<T> PreOrderTraversing(IIteratorBounding<T> boundingIterator)
        {
            PreOrderTraversing(RootNode, boundingIterator);
            return boundingIterator.GetIterator();
        }

        private void PreOrderTraversing(Node<T> root, IIteratorBounding<T> boundingIterator)
        {
            if (root.IsEmpty())
                return;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            boundingIterator.Add(valNode.Value); // Add value to bounding iterator

            PreOrderTraversing(valNode.Left, boundingIterator); // Traversing the left BSTree

            PreOrderTraversing(valNode.Right, boundingIterator); // Traversing the right BSTree
        }
        /// <summary>
        /// Left - Right - Node traversal
        /// </summary>
        /// <param name="boundingIterator"></param>
        public IIterator<T> PostOrderTraversing(IIteratorBounding<T> boundingIterator)
        {
            PostOrderTraversing(RootNode, boundingIterator);
            return boundingIterator.GetIterator();
        }

        private void PostOrderTraversing(Node<T> root, IIteratorBounding<T> boundingIterator)
        {
            if (root.IsEmpty())
                return;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            PostOrderTraversing(valNode.Left, boundingIterator); // Traversing the left BSTree

            PostOrderTraversing(valNode.Right, boundingIterator); // Traversing the right BSTree

            boundingIterator.Add(valNode.Value); // Add value to bounding iterator
        }
        /// <summary>
        /// Get BSTree height, return 0 if BSTree is empty, otherwise BSTree height
        /// </summary>
        public int GetHeight()
        {
            return GetHeight(RootNode);
        }
        private int GetHeight(Node<T> root)
        {
            if (root.IsEmpty())
                return 0;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            int hL = GetHeight(valNode.Left);
            int hR = GetHeight(valNode.Right);
            return hL > hR ? hL + 1 : hR + 1;
        }
        /// <summary>
        /// Count BSTree's node in each BSTree's floor
        /// </summary>
        public List<int> CountNodeInEachFloor()
        {
            if (RootNode.IsEmpty())
                return null;

            List<int> res = new List<int>();
            ValuableNode<T> valRoot = (ValuableNode<T>)RootNode;
            res.Add(1);
            
            if (!valRoot.IsSingle())
            {
                List<ValuableNode<T>> nodesFloor = new List<ValuableNode<T>>();
                nodesFloor.Add(valRoot);
                CountNodeInEachFloor(nodesFloor, ref res);
            }
            
            return res;
        }
        private void CountNodeInEachFloor(List<ValuableNode<T>> prevNodesFloor, ref List<int> floor)
        {
            int count = 0;
            List<ValuableNode<T>> nodesThisFloor = new List<ValuableNode<T>>();
            foreach (ValuableNode<T> node in prevNodesFloor)
            {
                if (!node.IsSingle())
                {
                    if (node.IsFullChilds())
                    {
                        count += 2;
                        nodesThisFloor.Add((ValuableNode<T>)node.Left);
                        nodesThisFloor.Add((ValuableNode<T>)node.Right);
                    }
                    else // Has left or right child only
                    {
                        count += 1;
                        if (node.IsLeftEmptyOnly())
                            nodesThisFloor.Add((ValuableNode<T>)node.Right);
                        else
                            nodesThisFloor.Add((ValuableNode<T>)node.Left);
                    }
                }
            }

            if (count != 0)
            {
                floor.Add(count);
                CountNodeInEachFloor(nodesThisFloor, ref floor);
            }
        }
        /// <summary>
        /// Get the path's length from Root to the node which contains a specific value
        /// <para>return</para>
        /// <para>&#8226; The path length</para>
        /// <para>&#8226; -1 if value doesn't exist in BSTree</para>
        /// </summary>
        public int GetPathLengthToNodeValue(T value)
        {
            return GetPathLengthToNodeValue(value, RootNode, _comparer);
        }
        private int GetPathLengthToNodeValue(T value, Node<T> root, ICComparer<T> comparer)
        {
            if (root.IsEmpty())
                return -1;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            int delta = comparer.Compare(value, valNode.Value);
            if (delta == 0)
                return 0;
            else if (delta < 0)
            {
                int lLeft = GetPathLengthToNodeValue(value, valNode.Left, comparer);
                return lLeft == -1 ? -1 : lLeft + 1;
            }
            else
            {
                int lRight = GetPathLengthToNodeValue(value, valNode.Right, comparer);
                return lRight == -1 ? -1 : lRight + 1;
            }
        }
        /// <summary>
        /// Count node in BSTree with specific criteria such as: total nodes, node is leaf, ...
        /// </summary>
        /// <param name="counter"></param>
        public int CountNodeSatisfy(Counter<T> counter)
        {
            int count = 0;
            counter.Count(RootNode, ref count);
            return count;
        }
        /// <summary>
        /// Search a node in BSTree with specific value
        /// </summary>
        public Node<T> SearchNodeValue(T value)
        {
            if (RootNode.IsEmpty())
                return new EmptyNode<T>();
            return ((ValuableNode<T>)RootNode).Find(value, _comparer);
        }
        /// <summary>
        /// Search a node with specific criteria such as: node has max value, node has max value in left child from root, ...
        /// <para>return</para>
        /// <para>      EmptyNode if criteria's not satisfy</para>
        /// </summary>
        /// <param name="searcher">Searching criteria</param>
        public Node<T> SearchNodeSatisfy(Searcher<T> searcher)
        {
            return searcher.Search(RootNode);
        }
    }
}
