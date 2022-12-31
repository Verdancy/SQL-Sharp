using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLInsertTable
    {
        private string TableName;
        private SQLVarsVals Variables = new SQLVarsVals();

        public SQLInsertTable(string table)
        {
            TableName = table;
        }
        public SQLInsertTable(string table, SQLVarsVals vars):this(table)
        {
            Variables = vars;
        }
        public void Add(params SQLVarsVals[] vars)
        {
            foreach (var v in vars)
                Variables.Add(v);
        }
        public void Add(string field, string value)
        {
            Variables.Add(new SQLVarVal(field, value));
        }
        public void Add(params SQLVarVal[] vars)
        {
            foreach (var v in vars)
                Variables.Add(v);
        }
        public SQLVarsVals GetVariables()
        {
            return Variables;
        }
        public string GetSql()
        {
            string fields = Variables.GetFieldNames();
            string values = Variables.GetFieldValues();
            return $"INSERT INTO {TableName} ({fields}) VALUES ({values});";
        }
        public string GetSqlWithParameters()
        {
            string fields = Variables.GetFieldNames();
            string pfields = Variables.GetParamFieldNames();
            return $"INSERT INTO {TableName} ({fields}) VALUES ({pfields});";
        }
        public SQLParamList GetParamList()
        {
            return new SQLParamList(Variables);                      
        }
        public string GetMySql()
        {
            return GetSql();
        }
        public string GetMySqlWithParameters()
        {
            return GetSqlWithParameters();
        }
    }
}
