using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLInsertTableMultiValues
    {
        private string TableName;
        private SQLVars Fields = new SQLVars();
        private List<SQLVals> Values = new List<SQLVals>();

        public SQLInsertTableMultiValues(string tablename)
        {
            TableName = tablename;
        }
        public SQLInsertTableMultiValues(string tablename, SQLVars fields):this(tablename)
        {
            Fields = fields;
        }
        public SQLInsertTableMultiValues(string tablename, SQLVars fields, List<SQLVars> Values):this(tablename, fields)
        {
            foreach (var v in Values)
                if (v.Count() == Fields.Count())
                    Values.Add(v);            
        }
        public void SetFields(SQLVars fields)
        {
            Fields = fields;
        }
        public void SetFields(params SQLVar[] fields)
        {
            foreach (var f in fields)
                Fields.Add(f);
        }
        public void SetFields(params string[] fields)
        {
            foreach (var f in fields)
                Fields.Add(new SQLVar(f));
        }
        public void AddValues(params SQLVal[] values)
        {
            if (Fields.Count() == values.Length)
                Values.Add(new SQLVals(values));
        }
        public void AddValues(params string[] values)
        {
            if (Fields.Count() == values.Length)
            {
                SQLVals temp = new SQLVals();
                temp.Add(values);
                Values.Add(temp);
            }
        }
        public List<SQLVarsVals> GetVariables()
        {
            List<SQLVarsVals> temp = new List<SQLVarsVals>();

            string[] fields = Fields.GetFieldNames().Split(',');
            for (int index = 0; index < Values.Count; index++)
            {
                SQLVarsVals var = new SQLVarsVals();
                for (int index2 = 0; index2 < fields.Length; index2++)
                    var.Add(fields[index2], Values[index].GetFieldValues(index2).GetRawValue());
                temp.Add(var);

            }
            return temp;
        }
        public string GetSql()
        {
            string command = $"INSERT INTO {TableName} ({Fields.GetFieldNames()}) VALUES ";
            foreach (var v in Values)
                command += $"({v.GetFieldValues()}), ";
            command = Utilities.RemoveLastComma(command) + ";";
            return command;
        }
        public string GetSqlWithParameters()
        {
            string fields = Fields.GetFieldNames();
            string pfields = Fields.GetParamFieldNames();
            return $"INSERT INTO {TableName} ({fields}) VALUES ({pfields});";
        }
       
        public List<SQLParamList> GetParams()
        {
            List<SQLParamList> temp = new List<SQLParamList>();
            string[] fields = Fields.GetFieldNames().Split(',');
            for (int index = 0; index < Values.Count; index++)
            {
                SQLParamList var = new SQLParamList();
                for (int index2 = 0; index2 < fields.Length; index2++)
                    var.Add($"@{fields[index2].Trim()}", Values[index].GetFieldValues(index2).GetRawValue());
                temp.Add(var);

            }
            return temp;
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
