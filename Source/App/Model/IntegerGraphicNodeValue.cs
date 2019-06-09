using BinarySearchTree.Model;
using System;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace App.Model
{
    public class IntegerGraphicNodeValue : GraphicNodeValue
    {
        public int Value { get; set; }
        public IntegerGraphicNodeValue(int value)
        {
            Value = value;
        }
        public override object GetValue()
        {
            return Value;
        }

        public override string ConvertToString()
        {
            return Value.ToString();
        }

        public override int Compare(INodeValue val2)
        {
            if (!(val2 is IntegerGraphicNodeValue))
                throw new ArgumentException("Argument must be an IntegerGraphicNode type");
            return Value - (int)val2.GetValue();
        }
    }
}
