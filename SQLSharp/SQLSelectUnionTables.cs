using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLSelectUnionTables
    {
        SQLJoinTable Table1;
        SQLJoinTable Table2;
        bool UnionAll = false;

        SQLSelectUnionTables(SQLJoinTable table1, SQLJoinTable table2, bool unionall = false)
        {
            Table1 = table1;
            Table2 = table2;
            UnionAll = unionall;
        }
        SQLSelectUnionTables(SQLSelectTable table1, SQLSelectTable table2, bool unionall=false)
        {
            Table1 = new SQLJoinTable(table1);
            Table2 = new SQLJoinTable(table2);
            UnionAll = unionall;
        }
        private string PrintAll()
        {
            if (UnionAll)
                return "ALL";
            else
                return "";
        }
        public string GetSql()
        {
            return $"{Table1.GetSql()} UNION {PrintAll()} {Table2.GetSql()};";
        }
        public string GetMySql()
        {
            return GetSql();
        }        
    }
}
