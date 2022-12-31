using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLSpecialSelectTable: SQLSelectTable, ISQLSelectTable
    {
        string SpecialAction = "COUNT";
        public SQLSpecialSelectTable(string MainTable):base(MainTable)
        { }
        public void MakeCount()
        {
            SpecialAction = "COUNT";
        }
        public void MakeAverage()
        {
            SpecialAction = "AVG";
        }
        public void MakeSUM()
        {
            SpecialAction = "SUM";
        }
        public void MakeMIN()
        {
            SpecialAction = "MIN";
        }
        public void MakeMAX()
        {
            SpecialAction = "MAX";
        }
        new public void AddSelectField(SQLVars field)
        {
            SelectFields = new SQLVars();
            SelectFields.Add(field);
        }
        new public void AddSelectField(string field1)
        {
            SelectFields = new SQLVars();
            SelectFields.Add(new SQLVar(field1));
        }
        [Obsolete("This method only adds the first item because Special Select can only have one Select Field")]
        new public void AddSelectField(params string[] fields)
        {
            SelectFields = new SQLVars();
            SelectFields.Add(new SQLVar(fields[0]));
        }
        new protected string GetSelectFrom()
        {
            return $"SELECT {GetDistinct()} {SpecialAction}({SelectFields.GetFieldNames()}) FROM {MainTable}";
        }
        new public virtual string GetSql()
        {
            return $"{ GetSelectFrom()} { GetWhere()} {GetGroupBy()} {GetHaving()} {GetOrderBy()};";
            //string command = $"SELECT {GetDistinct()} {SpecialAction}({SelectFields.GetFieldNames()}) FROM {MainTable}";
            //if (WhereFields.Count() > 0)
            //    command += $" WHERE {WhereFields.GetFieldOperandValueasStringorNum()}";
            //if (OrderByFields.Count() > 0)
            //    command += $" ORDER BY {OrderByFields.GetFieldNames()} ";
            //command += ";";
            //return command;

        }
        public override string GetSqlWithParameters()
        {
            return $"{ GetSelectFrom()}{GetWhereParam()}{GetGroupBy()}{GetHavingParam()}{GetOrderBy()};";
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
