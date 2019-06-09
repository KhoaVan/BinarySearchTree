using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Counter
{
    public class NodeTotalCounter<T> : Counter<T> where T : INodeValue
    {
        protected override bool MatchCondition(ValuableNode<T> valNode)
        {
            return true;
        }
    }
}
