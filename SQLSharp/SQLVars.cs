using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLVars
    {
        protected List<SQLVar> Fields = new List<SQLVar>();

        public SQLVars()
        {
            Fields = new List<SQLVar>();
        }
        /// <summary>
        /// Creates a list of the fieldnames from the list of variables with values
        /// </summary>
        /// <param name="separator">Contains the char to use as a separater</param>
        /// <returns></returns>
        /// 
        public SQLVars(SQLVar[] fields)
        {
            foreach (var f in fields)
                Fields.Add(f);
        }
        public void Add(SQLVars vars)
        {
            foreach (var v in vars.GetFields())
                Fields.Add(v);
        }
        public void Add(params string[] fields)
        {
            foreach (var f in fields)
                Fields.Add(new SQLVar(f));
        }
        public void Add(SQLVar field)
        {
            Fields.Add(field);
        }
        
        public List<SQLVar> GetFields()
        {
            return Fields;
        }
        public string GetFieldNames(string separator = ", ")
        {
            string temp = "";
            foreach (var v in Fields)
                temp += v.GetName() + separator;
            return Utilities.RemoveLastComma(temp);
        }
        public string GetParamFieldNames(string prefix="@", string separator = ", ")
        {
            string temp = "";
            foreach (var v in Fields)
                temp += $"{prefix}{v.GetName().Trim()}{separator}";
            return Utilities.RemoveLastComma(temp);
        }
        public int Count()
        {
            return Fields.Count;
        }
    }
}
