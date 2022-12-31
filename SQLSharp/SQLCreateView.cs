using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLCreateView:SQLJoinTable
    {
        string ViewName;

        public SQLCreateView(string tablename, string viewname) : base(tablename)
        {
            SetViewName(viewname);
        }
        public SQLCreateView(SQLSelectTable table, string viewname) : base(table)
        {
            SetViewName(viewname);
        }
        public SQLCreateView(SQLJoinTable table, string viewname) : base(table)
        {
            SetViewName(viewname);
        }
        public SQLCreateView(string maintable, SQLVars selectfields, string viewname) : base(maintable, selectfields)
        {
            SetViewName(viewname);
        }
        public SQLCreateView(string maintable, SQLVars selectfields, SQLWhereVars wherefields, string viewname) : base(maintable, selectfields, wherefields)
        {
            SetViewName(viewname);
        }
        public void SetViewName(string viewname)
        {
            ViewName = viewname;
        }
        protected string GetCreateViewAs()
        {
            return $"CREATE VIEW {ViewName} AS";
        }
        public override string GetSql()
        {
            return $"{GetCreateViewAs()} {GetSelectFrom()} {GetJoinON()} {GetWhere()} {GetGroupBy()} {GetHaving()} {GetOrderBy()};";
        }
        public override string GetSqlWithParameters()
        {
            return $"{GetCreateViewAs()} {GetSelectFrom()} {GetJoinON()} {GetWhereParam()} {GetGroupBy()} {GetHavingParam()} {GetOrderBy()};";
        }
        public override string GetMySql()
        {
            return GetSql();
        }
        public override string GetMySqlWithParameters()
        {
            return GetSqlWithParameters();
        }

    }
}
