using BinarySearchTree.Comparer;
using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree
{
    public class ValuableNode<T> : Node<T> where T : INodeValue
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }        

        /// <summary>
        /// Init single node from a single node
        /// </summary>
        /// <param name="node"></param>
        public ValuableNode(ValuableNode<T> node) : this(node.Value) { }
        public ValuableNode(T value) : this(value, new EmptyNode<T>(), new EmptyNode<T>(), new EmptyNode<T>()) { }
        public ValuableNode(T value, Node<T> parent) : this(value, parent, new EmptyNode<T>(), new EmptyNode<T>()) 
        {
            Left.Parent = Right.Parent = this;
        }
        public ValuableNode(T value, Node<T> parent, Node<T> left, Node<T> right)
        {
            Value = value;
            base.Parent = parent;
            Left = left;
            Right = right;
        }

        public override bool IsEmpty()
        {
            return false;
        }
        /// <summary>
        /// Default is true
        /// </summary>
        private bool _isChanged = true;

        public bool IsChanged
        {
            get
            {
                if (_isChanged)
                    return true;
                var childsChanged = false;
                if (!Left.IsEmpty())
                    childsChanged |= ((ValuableNode<T>)Left).IsChanged;
                if (!Right.IsEmpty())
                    childsChanged |= ((ValuableNode<T>)Right).IsChanged;
                return childsChanged;

            }

            set { _isChanged = value; }
        }
        /// <summary>
        /// Verify if node doesn't has any childs
        /// </summary>
        public bool IsSingle()
        {
            return Left.IsEmpty() && Right.IsEmpty();
        }
        public bool IsLeftEmptyOnly()
        {
            return !Right.IsEmpty() && Left.IsEmpty();
        }
        public bool IsRightEmptyOnly()
        {
            return Right.IsEmpty() && !Left.IsEmpty();
        }
        public bool IsFullChilds()
        {
            return !Left.IsEmpty() && !Right.IsEmpty();
        }
        /// <summary>
        /// <para>return</para>
        /// <para>&#8226; -1 if this is left of parent</para>
        /// <para>&#8226; 1 if this is right of parent</para>
        /// <para>&#8226; 0 if parent is empty</para>
        /// </summary>
        /// <returns></returns>
        public int PositionWithParent()
        {
            if (IsParentEmpty())
                return 0;
            if (((ValuableNode<T>)Parent).Left == this)
                return -1;
            return 1;
        }
        public bool Insert(T value, ICComparer<T> comparer)
        {
            bool res = false;
            if (comparer.Compare(value, Value) < 0)
            {
                res = true;
                IsChanged = true;
                if (Left.IsEmpty())
                    Left = new ValuableNode<T>(value, this);
                else
                    res = ((ValuableNode<T>)Left).Insert(value, comparer);
            }

            if (comparer.Compare(value, Value) > 0)
            {
                res = true;
                IsChanged = true;
                if (Right.IsEmpty())
                    Right = new ValuableNode<T>(value, this);
                else
                    res = ((ValuableNode<T>)Right).Insert(value, comparer);
            }

            return res;
        }
        public void Delete(T value, ICComparer<T> comparer)
        {
            Node<T> nodeToDel = Find(value, comparer);
            if (!nodeToDel.IsEmpty())
                Delete((ValuableNode<T>)nodeToDel, comparer);
        }
        private void Delete(ValuableNode<T> valNode, ICComparer<T> comparer)
        {
            valNode.IsChanged = true;
            if (valNode.IsSingle()) // Leaf node (not Root)
            {
                ValuableNode<T> valParent = (ValuableNode<T>)valNode.Parent;
                valParent.IsChanged = true; //
                if (valNode.PositionWithParent() < 0) // Left
                    valParent.Left = new EmptyNode<T>(valParent);
                else // Right
                    valParent.Right = new EmptyNode<T>(valParent);

                valNode = null;
            }
            else if (valNode.IsLeftEmptyOnly()) // Left node empty only (not Root)
            {
                ValuableNode<T> valParent = (ValuableNode<T>)valNode.Parent;
                if (valNode.PositionWithParent() < 0) // Left
                    valParent.Left = valNode.Right;
                else // Right
                    valParent.Right = valNode.Right;

                valNode.Right.Parent = valParent;
                ((ValuableNode<T>)valNode.Right).IsChanged = true; // 
                valNode = null;
            }
            else if (valNode.IsRightEmptyOnly()) // Right node empty only (not Root)
            {
                ValuableNode<T> valParent = (ValuableNode<T>)valNode.Parent;
                if (valNode.PositionWithParent() < 0) // Left
                    valParent.Left = valNode.Left;
                else // Right
                    valParent.Right = valNode.Left;

                valNode.Left.Parent = valParent;
                ((ValuableNode<T>)valNode.Left).IsChanged = true; //
                valNode = null;
            }
            else // Node full contains 2 childs
            {
                ValuableNode<T> maxLeftNode = ((ValuableNode<T>)valNode.Left).GetMaxValue();
                valNode.Value = maxLeftNode.Value;
                Delete(maxLeftNode, comparer);
            }
        }
        public Node<T> Find(T value, ICComparer<T> comparer)
        {
            int delta = comparer.Compare(value, Value);
            if (delta == 0)
                return this;
            if (delta < 0)
                return Left.IsEmpty() ? new EmptyNode<T>() : ((ValuableNode<T>)Left).Find(value, comparer);
            return Right.IsEmpty() ? new EmptyNode<T>() : ((ValuableNode<T>)Right).Find(value, comparer);
        }
        public ValuableNode<T> GetMaxValue()
        {
            return Right.IsEmpty() ? this : ((ValuableNode<T>)Right).GetMaxValue();
        }
        public ValuableNode<T> GetMinValue()
        {
            return Left.IsEmpty() ? this : ((ValuableNode<T>)Left).GetMinValue();
        }
    }
}
