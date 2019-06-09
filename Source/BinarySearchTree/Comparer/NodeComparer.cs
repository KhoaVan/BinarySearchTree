using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Comparer
{
    public class NodeComparer : ICComparer<INodeValue>
    {
        public int Compare(INodeValue val1, INodeValue val2)
        {
            return val1.Compare(val2);
        }
    }
}
