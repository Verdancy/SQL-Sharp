using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLVals
    {
        List<SQLVal> Fields = new List<SQLVal>();

        public SQLVals()
        {
            Fields = new List<SQLVal>();
        }
        public SQLVals(SQLVal[] fields)
        {
            foreach (var f in fields)
                Fields.Add(f);
        }
        public void Add(SQLVals vars)
        {
            foreach (var v in vars.GetFields())
                Fields.Add(v);
        }
        public void Add(params string[] fields)
        {
            foreach (var f in fields)
                Fields.Add(new SQLVal(f));
        }
        public void Add(SQLVal field)
        {
            Fields.Add(field);
        }

        public List<SQLVal> GetFields()
        {
            return Fields;
        }
        public string GetFieldValues(string separator = ", ")
        {
            string temp = "";
            foreach (var v in Fields)
                temp += v.GetValue() + separator;
            return Utilities.RemoveLastComma(temp);
        }
        public SQLVal GetFieldValues(int index)
        {
            return Fields[index];
        }
        public int Count()
        {
            return Fields.Count;
        }
    }
}
