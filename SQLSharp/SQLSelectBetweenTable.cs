using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLSelectBetweenTable : SQLJoinTable
    {
        private SQLVar BetweenField;
        private SQLVal Between1;
        private SQLVal Between2;
        private bool usenot = false;

        public SQLSelectBetweenTable(string tablename) : base(tablename)
        {
        }

        public SQLSelectBetweenTable(string maintable, SQLVars selectfields, SQLWhereVars wherefields, bool unot = false) : base(maintable, selectfields, wherefields)
        {
            usenot = unot;
        }
        public void AddBetweenField(string field)
        {
            BetweenField = new SQLVar(field);
        }
        public void AddBetweenValue1(string value, bool isnum = false)
        {
            Between1 = new SQLVal(value, isnum);
        }
        public void AddBetweenValue2(string value, bool isnum = false)
        {
            Between2 = new SQLVal(value, isnum);
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
            if ((WhereFields.Count() > 0) || (BetweenField != null))
            {
                command += $" WHERE ";
                if (BetweenField != null)
                    command += $"{BetweenField.GetName()} {GetNot()} BETWEEN ({Between1.GetValue()} AND {Between2.GetValue()}";
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
        
    }
}
