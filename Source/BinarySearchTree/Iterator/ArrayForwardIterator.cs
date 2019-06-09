using System.Collections.Generic;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Iterator
{
    public class ArrayForwardIterator<T> : IIterator<T>
    {
        private List<T> _data;
        private int _currentPos;
        public ArrayForwardIterator(List<T> data)
        {
            _data = data;
        }
        public void First()
        {
            _currentPos = 0;
        }

        public void Next()
        {
            if (IsDone())
                return;

            _currentPos++;
        }

        public bool IsDone()
        {
            return _currentPos == _data.Count;
        }

        public T Current()
        {
            return IsDone() ? default(T) : _data[_currentPos];
        }
    }
}
