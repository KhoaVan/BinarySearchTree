using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Comparer
{
    public class IntegerComparer : ICComparer<IntegerNode>
    {
        public int Compare(IntegerNode val1, IntegerNode val2)
        {
            return val1.Value - val2.Value;
        }
    }
}
