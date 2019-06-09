using System.Collections.Generic;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Iterator
{
    public class ArrayForwardIteratorBounding<T> : IIteratorBounding<T>
    {
        private List<T> _data;
        public ArrayForwardIteratorBounding()
        {
            _data = new List<T>();
        }
        public ArrayForwardIteratorBounding(List<T> data)
        {
            _data = data;
        }
        public void Add(T data)
        {
            _data.Add(data);
        }

        public IIterator<T> GetIterator()
        {
            return new ArrayForwardIterator<T>(_data);
        }
    }
}
