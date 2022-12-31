using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLVal
    {
        protected string Value;
        protected bool IsNum = false;

        public SQLVal()
        {
            Value = "";
        }
        public SQLVal(string val, bool isnum = false)
        {
            Value = val;
            IsNum = isnum;
        }
        public string GetValue()
        {
            if (IsNum)
                return Value;
            else
                return "'" + Value + "'";
        }
        public string GetRawValue()
        {
            return Value;
        }
        public bool GetIsNum()
        {
            return IsNum;
        }
    }
}
