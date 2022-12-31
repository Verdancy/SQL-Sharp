using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLVarVal:SQLVar
    {
        // private string Name;
        protected SQLVal Value = new SQLVal();
        //private string Value;
        //private bool IsNum;
        protected string Operand;
        //private string Constructor = "";
        /// <summary>
        /// Constructor to create a Variable Value connection variable
        /// </summary>
        /// <param name="nm">The name of the variable</param>
        /// <param name="val">The value of the variable</param>
        /// <param name="isnum">Whether it should be seen as a number</param>
        public SQLVarVal(string nm, string val, string operand = " = ", bool isnum = false) : base(nm)
        {
            
            Value = new SQLVal(val, isnum);
            //IsNum = isnum;
            Operand = operand;

        }
        public SQLVarVal(SQLVarVal value): base(value.GetName())
        {
            Value = new SQLVal(value.GetRawValue(), value.GetIsNum());
            Operand = value.GetOperand();           
        }
        /// <summary>
        /// Constructor to create a variable value connection instance
        /// </summary>
        /// <param name="field">A SQLiteField variable to be used to name the variable</param>
        /// <param name="val">The value of the new variable</param>
        /// <param name="isnum">Whether it should be considered a number</param>
        public SQLVarVal(SQLField field, string val, string operand = " = ", bool isnum=false):this(field.GetName(), val, operand, isnum)
        {

        }
        
       
        /// <summary>
        /// Returns the variable based on whether or not it is a number
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return Value.GetValue();
            //if (IsNum)
            //    return Value;
            //else
            //    return "'" + Value + "'";
        }
        /// <summary>
        /// returns the value of the variable 
        /// </summary>
        /// <returns></returns>
        public string GetRawValue()
        {
            return Value.GetRawValue();
        }
        public bool GetIsNum()
        {
            return Value.GetIsNum();
        }
        public string GetOperand()
        {
            return Operand;
        }
        public SQLParam GetasParam(string prefix = "@")
        {
            return new SQLParam($"{prefix}{Name}", Value.GetRawValue());
        }
        //public string GetConstructor()
        //{
        //    return Constructor;
        //}
    }
}
