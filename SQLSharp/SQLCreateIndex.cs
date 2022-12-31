using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLCreateIndex
    {
        private string IndexName;
        private string TableName;
        private SQLVars Columns;
        private bool unique = false;
        public SQLCreateIndex(string index, string table, bool isunique = false)
        {
            IndexName = index;
            TableName = table;
            unique = isunique;
        }
        public SQLCreateIndex(string index, string table, string column, bool isunique = false) : this(index, table, new SQLVar(column), isunique)
        {

        }
        public SQLCreateIndex(string index, string table, SQLVar column, bool isunique = false) : this(index, table, isunique)
        {

            Columns.Add(column);
        }
        public SQLCreateIndex(string index, string table, SQLVars columns, bool isunique = false) : this(index, table, isunique)
        {
            Columns.Add(columns);
        }
        private string GetUniquePhrase()
        {
            if (unique)
                return "UNIQUE";
            else
                return "";
        }
        protected string GetCreateIndex()
        {
            return $"CREATE {GetUniquePhrase()} INDEX {IndexName}";
        }
        protected string GetON()
        {
            return $"ON {TableName} ({Columns.GetFieldNames()})";
        }

        public string GetSql()
        {
            return $"{GetCreateIndex()} {GetON()};";
        }
        public string GetMySql()
        {
            return GetSql();
        }
    }
}
