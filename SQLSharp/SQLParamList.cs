using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLParamList
    {
        private List<SQLParam> Parameters = new List<SQLParam>();

        public SQLParamList()
        {
            Parameters = new List<SQLParam>();
        }
        public SQLParamList(SQLParamList parameters)
        {
            Parameters = parameters.GetParameters();
        }
        public SQLParamList(SQLVarsVals vars, string prefix = "@")
        {
            for (int index = 0; index < vars.Count(); index++)
            {
                Parameters.Add(new SQLParam($"{prefix}{vars.GetName(index)}", vars.GetValue(index)));
            }
        }
        public SQLParam this[int index]
        {
            get
            {
                if ((index >= 0)&&(Parameters.Count > 0))
                {
                    if (index < Parameters.Count)
                        return Parameters[index];                    
                    else 
                        return Parameters[Parameters.Count - 1];                    
                }
                else
                    return null;
            }
            set
            {
                try
                {
                    Parameters[index] = value;
                }
                catch
                {
                    Parameters.Add(value);
                }
            }
        }
        public void Add(SQLParam par)
        {
            Parameters.Add(par);
        }
        public void Add(SQLParamList pars)
        {
            foreach (var p in pars.GetParameters())
                Parameters.Add(p);
        }
        public void Add(string parameter, string val)
        {
            Parameters.Add(new SQLParam(parameter, val));
        }
        public List<SQLParam> GetParameters()
        {
            return Parameters;
        }
        public string GetParameter(int index)
        {
            return Parameters[index].GetParam();
        }
        public string GetValue(int index)
        {
            return Parameters[index].GetValue();
        }
        public SQLParam GetSQLParam(int index)
        {
            return Parameters[index];
        }
        public string GetParamsList(string separator = ", ")
        {
            string temp = "";
            foreach (var p in Parameters)
                temp += $"{p.GetParam()}{separator}";
            return Utilities.RemoveLastComma(temp);
        }
        public int Count()
        {
            return Parameters.Count;
        }
        public override string ToString()
        {
            string temp = "";
            foreach (var p in Parameters)
                temp += $"{p.ToString()}{Environment.NewLine}";
            return temp;
        }
    }
}
