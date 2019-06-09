using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Searcher
{
    public class NodeMinInRightChildSearcher<T> : Searcher<T> where T : INodeValue
    {
        protected override Node<T> DoInSearch(ValuableNode<T> node)
        {
            if (node.Right.IsEmpty())
                return new EmptyNode<T>();
            return ((ValuableNode<T>)node.Right).GetMinValue();
        }
    }
}
