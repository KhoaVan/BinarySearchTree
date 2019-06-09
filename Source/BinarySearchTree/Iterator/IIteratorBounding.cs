/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Iterator
{
    public interface IIteratorBounding<T>
    {
        void Add(T data);
        IIterator<T> GetIterator();
    }
}
