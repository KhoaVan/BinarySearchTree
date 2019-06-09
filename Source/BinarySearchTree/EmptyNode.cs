/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree
{
    public class EmptyNode<T>: Node<T>
    {
        public EmptyNode() 
        {
        }

        public EmptyNode(Node<T> parent)
        {
            base.Parent = Parent;
        }
        public override bool IsEmpty()
        {
            return true;
        }
    }
}
