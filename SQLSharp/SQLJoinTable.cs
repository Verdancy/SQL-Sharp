using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLJoinTable : SQLSelectTable, ISQLSelectTable
    {
        protected List<string> JoinTables = new List<string>();
        protected List<SQLJoinFields> JoinFields = new List<SQLJoinFields>();
     
        public SQLJoinTable(string maintable, List<string> jointables, List<SQLJoinFields> joinfields, SQLVars selectfields, SQLWhereVars wherefields):base(maintable,selectfields,wherefields)
        {
            if (jointables.Count == joinfields.Count)
            {               
                JoinTables = jointables;
                JoinFields = joinfields;                
            }
        }
        public SQLJoinTable(SQLSelectTable table) : base(table)
        {
        }
        public SQLJoinTable(SQLJoinTable table): this(table.GetMainTable(), table.GetJoinTables(), table.GetJoinFields(), table.GetSelectFields(), table.GetWhereFields())
        {
        }
        public SQLJoinTable(string maintable):base(maintable)
        {            
        }
        public SQLJoinTable(string maintable, SQLVars selectfields):base(maintable, selectfields)
        { }
        public SQLJoinTable(string maintable, SQLVars selectfields, SQLWhereVars wherefields) : base(maintable, selectfields, wherefields)
        { }
        List<string> GetJoinTables()
        {
            return JoinTables;
        }
        List<SQLJoinFields> GetJoinFields()
        {
            return JoinFields;
        }
        public void AddJoinTable(string jt, SQLJoinFields jf)
        {
            JoinTables.Add(jt);
            JoinFields.Add(jf);
        }        
        public void AddJoinTable(string jt, string field1, string field2, string operand = " = ")
        {
            JoinTables.Add(jt);
            JoinFields.Add(new SQLJoinFields(field1, field2, operand));
        }        
        protected string GetJoinON()
        {
            string command = "";
            if (JoinTables.Count > 0)
            {
                if (JoinTables.Count == JoinFields.Count)
                    for (int index = 0; index < JoinTables.Count; index++)
                        command += $" {JoinFields[index].GetJoinType()} JOIN {JoinTables[index]} ON {JoinFields[index].GetJoinSQL()}";
            }
            return command;
        }
        public override string GetSql()
        {
            return $"{ GetSelectFrom()} {GetJoinON()} {GetWhere()} {GetGroupBy()} {GetHaving()} {GetOrderBy()};";
            //string command = $"SELECT {GetDistinct()} {SelectFields.GetFieldNames()} FROM {MainTable}";
            //if (JoinTables.Count == JoinFields.Count)
            //    for (int index = 0; index < JoinTables.Count; index++)
            //        command += $" {JoinFields[index].GetJoinType()} JOIN {JoinTables[index]} ON {JoinFields[index].GetJoinSQL()}";
            //if (WhereFields.Count() > 0)
            //    command += $" WHERE {WhereFields.GetFieldOperandValueasStringorNum()}";
            //if (OrderByFields.Count() > 0)
            //    command += $" ORDER BY {OrderByFields.GetFieldNames()} ";
            //command += ";";
            //return command;
            
        }
        public override string GetSqlWithParameters()
        {
            return $"{ GetSelectFrom()} {GetJoinON()} {GetWhereParam()} {GetGroupBy()} {GetHavingParam()} {GetOrderBy()};";
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
