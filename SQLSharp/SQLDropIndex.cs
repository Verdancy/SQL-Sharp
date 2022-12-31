using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLDropIndex
    {
        private string IndexName;
        private string TableName;
        public SQLDropIndex(string indexname, string tablename="")
        {
            IndexName = indexname;
            TableName = tablename;
        }
        public string GetSql()
        {
            return $"DROP INDEX {IndexName};";
        }
        public string GetSqlServ()
        {
            return $"DROP INDEX {TableName}.{IndexName};";
        }
        public string GetMySql()
        {
            return $"ALTER TABLE {TableName} DROP INDEX {IndexName}";
        }
    }
}
