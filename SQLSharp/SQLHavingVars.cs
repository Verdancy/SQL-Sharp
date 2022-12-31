using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLHavingVars
    {
        List<SQLHavingVar> Variables = new List<SQLHavingVar>();

        public SQLHavingVars()
        {
            Variables = new List<SQLHavingVar>();
        }
        public SQLHavingVars(List<SQLHavingVar> vars)
        {
            Variables = vars;
        }
        public SQLHavingVars(string function, string nm, string value, string operand = "= ", bool isnum = false)
        {
            Variables.Add(new SQLHavingVar(function,"", nm, value, operand, isnum));
        }
        public SQLHavingVars(string function, string con, string nm, string value, string operand = "= ", bool isnum = false)
        {
            Variables.Add(new SQLHavingVar(function, con, nm, value, operand, isnum));
        }
        public SQLHavingVar this[int index]
        {
            get
            {
                if ((index >= 0) && (Variables.Count > 0))
                {
                    if (index < Variables.Count)
                        return Variables[index];
                    else
                        return Variables[Variables.Count - 1];
                }
                else
                    return null;
            }
            set
            {
                try
                {
                    Variables[index] = value;
                }
                catch
                {
                    Variables.Add(value);
                }
            }
        }
        public void Add(string function, SQLVarVal field)
        {
            Variables.Add(new SQLHavingVar(function,"", field));
        }
        public void Add(string function,string con, SQLVarVal field)
        {
            Variables.Add(new SQLHavingVar(function, con, field));
        }
        public void Add(string function, string con, string field1, string field2, string operand = " = ", bool isnum = false)
        {
            Variables.Add(new SQLHavingVar(function, con, field1, field2, operand, isnum));
        }
        public void Add(string function, SQLWhereVar field)
        {
            Add(function, field.GetConstructor(), field.GetName(), field.GetValue(), field.GetOperand(), field.GetIsNum());
        }
        public string GetHavingStatements()
        {
            string temp = "";
            foreach (var h in Variables)
                temp += h.GetStatement();
            return temp;
        }
        public string GetHavingParamStatements(string prefix="@")
        {
            string temp = "";
            foreach (var h in Variables)
                temp += h.GetParamStatement(prefix);
            return temp;
        }
        public int Count()
        {
            return Variables.Count;
        }

        public string GetFieldNames(string separator = ", ")
        {
            string temp = "";
            foreach (var v in Variables)
                temp += v.GetName() + separator;
            return Utilities.RemoveLastComma(temp);
        }
        public string GetFieldValues(string separator = ", ")
        {
            string temp = "";
            foreach (var v in Variables)
                temp += v.GetRawValue() + separator;
            return Utilities.RemoveLastComma(temp);
        }
        public SQLParamList GetParameterList(string prefix = "@")
        {
            SQLParamList parlist = new SQLParamList();
            foreach (var v in Variables)
                parlist.Add(v.GetasParam(prefix));
            return parlist;
        }
        public string GetParameterListString(string prefix = "@", string separator = ", ")
        {
            string temp = "";
            foreach (var v in Variables)
                temp += $"{v.GetAsParameter(prefix)}{separator}";
            return Utilities.RemoveLastComma(temp);
        }
    }
}
