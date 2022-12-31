using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLParam
    {
        string Parameter = "";
        string Value = "";

        public SQLParam(string par, string val="")
        {
            Parameter = par;
            Value = val;
        }
        public string GetParam()
        {
            return Parameter;
        }
        public string GetValue()
        {
            return Value;
        }
        public override string ToString()
        {
            return $"{Parameter} = {Value}";
        }
    }
}
