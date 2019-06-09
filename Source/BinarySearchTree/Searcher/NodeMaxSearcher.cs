using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Searcher
{
    public class NodeMaxSearcher<T> : Searcher<T> where T : INodeValue
    {
        protected override Node<T> DoInSearch(ValuableNode<T> node)
        {
            return node.GetMaxValue();
        }
    }
}
