using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLSelectInTable:SQLJoinTable
    {
        SQLVar WhereInField;
        SQLVals WhereINValues = new SQLVals();
        SQLSelectTable SelectInTable;
        private bool usenot = false;
        public SQLSelectInTable(string table):base(table)
        { }
        public SQLSelectInTable(string table, bool unot = false) : base(table)
        {
            usenot = unot;
        }
        public SQLSelectInTable(string maintable, SQLVars selectfields, SQLWhereVars wherefields, bool unot = false) : base(maintable, selectfields, wherefields)
        {
            usenot = unot;
        }
        public void UseNot()
        {
            usenot = true;
        }
        public void UseNoNot()
        {
            usenot = false;
        }
        public void AddWhereInField(SQLVarVal field)
        {
            WhereInField = new SQLVar(field.GetName());
            WhereINValues.Add(new SQLVal(field.GetRawValue(), field.GetIsNum()));
            
        }
        public void AddWhereInField(string field1, string field2, bool isnum = false)
        {
            WhereInField = new SQLVar(field1);
            WhereINValues.Add(new SQLVal(field2, isnum));
        }
        public void AddWhereInField(string field)
        {
            WhereInField = new SQLVar(field);
        }
        public void AddWhereInValue(string value, bool isnum=false)
        {
            WhereINValues.Add(new SQLVal(value, isnum));
        }
        public void AddWhereInSelect(SQLSelectTable table)
        {
            SelectInTable = table;
        }
        public string GetNot()
        {
            if (usenot)
                return "NOT";
            else
                return "";
               
        }
        new protected string GetWhere()
        {
            string command = "";
            if ((WhereFields.Count() > 0) || (WhereINValues.Count() > 0) || SelectInTable != null)
            {
                command += $" WHERE ";
                if (WhereINValues.Count() > 0)
                    command += $"{WhereInField.GetName()} {GetNot()} IN ({WhereINValues.GetFieldValues()}) ";
                else if (SelectInTable != null)
                    command += $"{WhereInField.GetName()} {GetNot()} IN ({SelectInTable.GetSql()}) ";
                if (WhereFields.Count() > 0)
                    command += $"{WhereFields.GetFieldOperandValueasStringorNum()}";
            }
            return command;
        }
        public override string GetSql()
        {
            return $"{GetSelectFrom()}{GetJoinON()}{GetWhere()}{GetGroupBy()}{GetHaving()}{GetOrderBy()};";
        }
        public override string GetMySql()
        {
            return GetSql();
        }
        
        //new public string GetSql()
        //{
        //    string command = $"SELECT {GetDistinct()} {SelectFields.GetFieldNames()} FROM {MainTable}";
        //    if (JoinTables.Count == JoinFields.Count)
        //        for (int index = 0; index < JoinTables.Count; index++)
        //            command += $" {JoinFields[index].GetJoinType()} JOIN {JoinTables[index]} ON {JoinFields[index].GetJoinSQL()}";
        //    if ((WhereFields.Count() > 0) || (WhereINValues.Count() > 0) ||SelectInTable != null)
        //    {
        //        command += $" WHERE ";
        //        if (WhereINValues.Count() > 0)
        //            command += $"{WhereInField.GetName()} IN ({WhereINValues.GetFieldValues()}) ";
        //        else if (SelectInTable != null)
        //            command += $"{WhereInField.GetName()} IN ({SelectInTable.GetSql()}) ";
        //        if (WhereFields.Count() > 0)
        //        command += $"{WhereFields.GetFieldOperandValueasStringorNum()}";
        //    }
        //    if (OrderByFields.Count() > 0)
        //        command += $" ORDER BY {OrderByFields.GetFieldNames()}";
        //    command += ";";
        //    return command;

        //}
    }
}
