using System;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Model
{
    public interface INodeValue
    {
        Object GetValue();
        int Compare(INodeValue val2);
        string ConvertToString();
    }
}
