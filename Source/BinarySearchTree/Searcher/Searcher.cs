using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Searcher
{
    public abstract class Searcher<T> where T : INodeValue
    {
        public Node<T> Search(Node<T> root)
        {
            if (root.IsEmpty())
                return new EmptyNode<T>();
            return DoInSearch((ValuableNode<T>)root);
        }
        protected abstract Node<T> DoInSearch(ValuableNode<T> node);
    }
}
