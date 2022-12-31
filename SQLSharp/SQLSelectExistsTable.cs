using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLSelectExistsTable:SQLJoinTable
    {
        
        private SQLJoinTable WhereTable;

        public SQLSelectExistsTable(string table):base(table)
        {            
        }
        public SQLSelectExistsTable(string table, SQLVars selectfields): base(table, selectfields)
        {            
        }
        public SQLSelectExistsTable(string table, SQLVars selectfields, SQLJoinTable wheretable):this(table, selectfields)
        {                   
            WhereTable = wheretable;
        }
        public SQLSelectExistsTable(string table, SQLVars selectfields, SQLSelectTable wheretable): this(table, selectfields, new SQLJoinTable(wheretable))
        {
        }
        public void SetWhereTable(string table, SQLVars selectfields)
        {
            WhereTable = new SQLJoinTable(table, selectfields);
        }
        public void SetWhereTable(SQLJoinTable table)
        {
            WhereTable = new SQLJoinTable(table);
        }
        public void SetWhereTable(SQLSelectTable table)
        {
            WhereTable = new SQLJoinTable(table);
        }
        new protected string GetWhere()
        {
            return $"WHERE EXISTS ({WhereTable.GetSql()})";
        }
        public override string GetSql()
        {
            return $"{ GetSelectFrom()} {GetJoinON()} {GetWhere()} {GetGroupBy()} {GetHaving()} {GetOrderBy()};";
        }
        public override string GetMySql()
        {
            return GetSql();
        }        
    }
}
