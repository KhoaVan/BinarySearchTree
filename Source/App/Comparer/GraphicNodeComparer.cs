using BinarySearchTree.Comparer;
using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace App.Comparer
{
    public class GraphicNodeComparer : ICComparer<GraphicNodeValue>
    {
        public int Compare(GraphicNodeValue val1, GraphicNodeValue val2)
        {
            return val1.Compare(val2);
        }
    }
}
