using BinarySearchTree.Model;
using System;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace App.Model
{
    public class StringGraphicNodeValue : GraphicNodeValue
    {
        public StringGraphicNodeValue(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }

        public override string ConvertToString()
        {
            return Value;
        }

        public override int Compare(INodeValue val2)
        {
            if (!(val2 is StringGraphicNodeValue))
                throw new ArgumentException("Argument must be a StringGraphicNode type");
            return string.Compare(Value, val2.ConvertToString());
        }
    }
}
