using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLInsertIntoSelectTable
    {
        string IntoTableName;
        SQLVars Fields;
        SQLJoinTable SelectTable;

        public SQLInsertIntoSelectTable(string nm)
        {
            IntoTableName = nm;
        }
        public SQLInsertIntoSelectTable(string nm, SQLVars fields):this(nm)
        {
            Fields = fields;
        }
        public SQLInsertIntoSelectTable(string nm, SQLVars fields, SQLJoinTable selectable): this(nm, fields)
        {
            SelectTable = selectable;
        }
        public SQLInsertIntoSelectTable(string nm, SQLVars fields, SQLSelectTable selectable) : this(nm, fields)
        {
            SelectTable = new SQLJoinTable(selectable);
        }
        public void AddField(params SQLVar[] vars)
        {
            foreach (var v in vars)
                Fields.Add(v);
        }
        public void AddField(string field)
        {
            Fields.Add(new SQLVar(field));
        }
        public void AddField(params SQLVarVal[] vars)
        {
            foreach (var v in vars)
                Fields.Add(v.GetName());
        }
        public void AddField(SQLVars vars)
        {
            Fields.Add(vars);
        }
        public void AddSelectTable(SQLSelectTable table)
        {
            SelectTable = new SQLJoinTable(table);
        }
        public void AddSelectTable(SQLJoinTable table)
        {
            SelectTable = new SQLJoinTable(table);
        }
        public void AddSelectTable(string maintable, SQLVars selectfields, SQLWhereVars wherefields)
        {
            SelectTable = new SQLJoinTable(maintable, selectfields, wherefields);
        }
        public void AddSelectTable(string maintable, List<string> jointables, List<SQLJoinFields> joinfields, SQLVars selectfields, SQLWhereVars wherefields)
        {
            SelectTable = new SQLJoinTable(maintable, jointables, joinfields, selectfields, wherefields);
        }
        public void MakeSelectTableDistinct()
        {
            SelectTable.MakeDistinct();
        }
        public void MakeSelectTableNotDistinct()
        {
            SelectTable.MakeNotDistinct();
        }
        public void AddJoinTable(string jt, SQLJoinFields jf)
        {
            SelectTable.AddJoinTable(jt, jf);
        }
        public void AddJoinTable(string jt, string field1, string field2, string operand = " = ")
        {
            SelectTable.AddJoinTable(jt, field1, field2, operand);
        }
            protected string GetInsert()
        {
            return $"INSERT INTO {IntoTableName} ({Fields.GetFieldNames()})";
        }
        public string GetSql()
        {
            return $"{GetInsert()} {SelectTable.GetSql()}";
        }
        public string GetMySql()
        {
            return GetSql();
        }
    }
}
