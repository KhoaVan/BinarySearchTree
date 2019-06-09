using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Searcher
{
    public class NodeMaxInLeftChildSearcher<T> : Searcher<T> where T : INodeValue
    {
        protected override Node<T> DoInSearch(ValuableNode<T> node)
        {
            if (node.Left.IsEmpty())
                return new EmptyNode<T>();
            return ((ValuableNode<T>)node.Left).GetMaxValue();
        }
    }
}
