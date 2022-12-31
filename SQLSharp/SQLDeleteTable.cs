using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLDeleteTable
    {
        private string TableName;
        private SQLWhereVars WhereFields = new SQLWhereVars();
        bool AllFields = false;

        public SQLDeleteTable(string table)
        {
            TableName = table;
        }
        public SQLDeleteTable(string table, SQLWhereVars where):this(table)
        {
            WhereFields = where;
        }
        public SQLDeleteTable(string table, SQLWhereVars where, bool allfields): this(table, where)
        {
            AllFields = allfields;
        }
        public SQLDeleteTable(string table, string field, string value, string operand = " = ", bool isnum = false):this(table, new SQLWhereVars(field, value, operand, isnum))
        {
        }
        public void DeleteAllRecords(bool deleteall)
        {
            AllFields = deleteall;
        }
        public void AddWhereField(SQLVarVal field)
        {
            WhereFields.Add(field);
        }
        public void AddWhereField(string field1, string field2, string con = "", string operand = " = ", bool isnum = false)
        {
            WhereFields.Add(new SQLWhereVar(con, field1, field2, operand, isnum));
        }
        private string DeleteAll()
        {
            if (AllFields)
                return " * ";
            else
                return "";
        }
        public string GetSql()
        {
            string command = "";
            if ((WhereFields.Count() > 0) || (AllFields))
            {
                command = $"DELETE {DeleteAll()} FROM {TableName}";
                if (WhereFields.Count() > 0)
                    command += $"WHERE {Utilities.RemoveLastComma(WhereFields.GetFieldOperandValueasStringorNum())};";
            }
            return command;
        }
        public string GetSqlWithParameters()
        {
            string command = "";
            if ((WhereFields.Count() > 0) || (AllFields))
            {
                command = $"DELETE {DeleteAll()} FROM {TableName}";
                if (WhereFields.Count() > 0)
                    command += $"WHERE {Utilities.RemoveLastComma(WhereFields.GetWhereFieldEqualsParameter())};";
            }
            return command;
        }
        public SQLParamList GetParamList()
        {
            SQLParamList temp = new SQLParamList();
            if (WhereFields.Count() > 0)
                temp.Add(WhereFields.GetParameterList());           
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
