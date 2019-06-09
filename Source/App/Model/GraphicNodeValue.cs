using System.Drawing;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Model
{
    public abstract class GraphicNodeValue : INodeValue
    {
        /// <summary>
        /// the last up to date image of current node and it's childs.
        /// </summary>
        public Image LastImage { get; set; }
        /// <summary>
        /// the location of the node on the top of the _lastImage.
        /// </summary>
        public int LastImageLocationOfStarterNode { get; set; }
        public abstract object GetValue();
        public abstract string ConvertToString();
        public abstract int Compare(INodeValue val2);
    }
}
