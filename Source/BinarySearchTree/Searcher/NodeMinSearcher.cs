using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Searcher
{
    public class NodeMinSearcher<T> : Searcher<T> where T : INodeValue
    {
        protected override Node<T> DoInSearch(ValuableNode<T> node)
        {
            return node.GetMinValue();
        }
    }
}
