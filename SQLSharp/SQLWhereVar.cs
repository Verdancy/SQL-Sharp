using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLWhereVar:SQLVarVal
    {
        protected string Constructor = "";
        public SQLWhereVar(string con, string nm, string value, string operand= "= ", bool isnum = false) : base(nm, value, operand, isnum)
        {
            Constructor = con;
        }
        public SQLWhereVar(string con, SQLVarVal value):base(value)
        {
            Constructor = con;
        }
        public SQLWhereVar(string nm, string value):base(nm, value)
        {
            Constructor = "";
        }
        public SQLWhereVar(string con, SQLField field, string val, string operand = " = ", bool isnum = false) : this(con, field.GetName(), val, operand, isnum)
        {      
        }        
        public string GetConstructor()
        {
            return Constructor;
        }

        
    }
}
