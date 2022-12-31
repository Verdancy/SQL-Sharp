using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLHavingVar:SQLWhereVar
    {
        string Function;

        public SQLHavingVar(string fun, string con, string nm, string value, string operand = "= ", bool isnum = false) : base(con,nm, value, operand, isnum)
        {
            Function = fun;
        }
        public SQLHavingVar(string fun, string con, SQLVarVal value) : base(con,value)
        {
            Function = fun;
        }
        public SQLHavingVar(string fun, string nm, string value) : base(nm, value)
        {
            Function = fun;
        }        
        public string GetFunction()
        {
            return Function;
        }
        public string GetStatement()
        {
            return $"{Constructor} {Function}({Name}) {Operand} {Value} ";
        }
        public string GetParamStatement(string prefix = "@")
        {
            return $"{Constructor} {Function}({Name}) {Operand} {prefix}{Name} ";
        }
    }
}
