using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLDropDB
    {
        string DataBase;
        public SQLDropDB(string database)
        {
            DataBase = database;
        }
        public string GetDB()
        {
            return DataBase;
        }
        public void setDB(string database)
        {
            DataBase = database;
        }
        public string GetSql()
        {
            return $"DROP DATABASE {DataBase};";
        }
        public string GetMySql()
        {
            return GetSql();
        }
    }
}
