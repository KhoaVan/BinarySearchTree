/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Iterator
{
    public interface IIterator<T>
    {
        void First();
        void Next();
        bool IsDone();
        T Current();
    }
}
