using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLOrderVars
    {
        List<SQLOrderVar> Variables = new List<SQLOrderVar>();

        public SQLOrderVars()
        {
            Variables = new List<SQLOrderVar>();
        }
        public SQLOrderVars(List<SQLOrderVar> vars)
        {
            Variables = vars;
        }
        public SQLOrderVar this[int index]
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
        public void Add(params SQLOrderVar[] vars)
        {
            foreach (var v in vars)
                Variables.Add(v);
        }
        public void Add(string field, string order)
        {
            Variables.Add(new SQLOrderVar(field, order));
        }
        public void Add(SQLVar field, string order)
        {
            Variables.Add(new SQLOrderVar(field.GetName(), order));
        }
        public string GetFieldNames(string separator = ", ")
        {
            string temp = "";
            foreach (var v in Variables)
                temp += $"{v.GetName()} {v.GetOrder()}{separator}";
            return Utilities.RemoveLastComma(temp);
        }
        
        public List<SQLOrderVar> GetVars()
        {
            return Variables;
        }
        public int Count()
        {
            return Variables.Count;
        }

    }
}
