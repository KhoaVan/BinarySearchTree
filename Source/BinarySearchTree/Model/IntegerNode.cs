using System;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace BinarySearchTree.Model
{
    public class IntegerNode : INodeValue
    {
        public int Value { get; set; }
        public IntegerNode(int value)
        {
            Value = value;
        }
        public object GetValue()
        {
            return Value;
        }
        public string ConvertToString()
        {
            return Value.ToString();
        }
        public int Compare(INodeValue val2)
        {
            if (!(val2 is IntegerNode))
                throw new ArgumentException("Argument is not an IntegerNode type");
            return Value - (int)val2.GetValue();
        }
    }
}
