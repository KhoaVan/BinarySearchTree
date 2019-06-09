using BinarySearchTree.Model;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Comparer
{
    public interface ICComparer<T> where T : INodeValue
    {
        /// <summary>
        /// <para>return</para> 
        /// <para>&#8226; negative value if val1 &#60; val2</para> 
        /// <para>&#8226; positive value if val1 &#62; val2</para> 
        /// <para>&#8226; 0 if val1 &#61; val2</para> 
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        int Compare(T val1, T val2);
    }
}
