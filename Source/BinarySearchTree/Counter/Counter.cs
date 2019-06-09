using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Counter
{
    public abstract class Counter<T> where T : INodeValue
    {
        public void Count(Node<T> root, ref int count)
        {
            if (root.IsEmpty())
                return;

            ValuableNode<T> valNode = (ValuableNode<T>)root;
            if (MatchCondition(valNode))
                count++;
            Count(valNode.Left, ref count);
            Count(valNode.Right, ref count);
        }
        protected abstract bool MatchCondition(ValuableNode<T> valNode);
    }
}
