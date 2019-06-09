/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree
{
    public abstract class Node<T>
    {
        public Node<T> Parent { get; set; }
        public Node() { }
        public abstract bool IsEmpty();
        public bool IsParentEmpty()
        {
            return Parent == null || Parent.IsEmpty();
        }
        
    }
}
