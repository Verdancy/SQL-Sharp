using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLUpdateTable
    {
        private string TableName;
        private SQLVarsVals Variables = new SQLVarsVals();
        private SQLWhereVars WhereFields = new SQLWhereVars();

        public SQLUpdateTable(string tablename)
        {
            TableName = tablename;
        }
        public SQLUpdateTable(string tablename, SQLVarsVals vars) : this(tablename)
        {
            Variables = vars;
        }
        public SQLUpdateTable(string tablename, SQLVarsVals vars, SQLWhereVars where): this(tablename, vars)
        {
            WhereFields = where;
        }
        public SQLUpdateTable(string tablename, SQLVarVal var, SQLWhereVar where): this(tablename)
        {
            Variables.Add(var);
            WhereFields.Add(where);
        }
        public void AddField(string name, string value, bool isnum = false, string operand = " = ")
        {
            Variables.Add(new SQLVarVal(name, value, operand, isnum));
        }
        public void AddField(params SQLVarsVals[] vars)
        {
            foreach (var v in vars)
                Variables.Add(v);
        }
        public void AddField(params SQLVarVal[] vars)
        {
            foreach (var v in vars)
                Variables.Add(v);
        }
        public void AddWhereField(SQLVarVal field)
        {
            WhereFields.Add(field);
        }
        public void AddWhereField(string field1, string field2, string con = "", string operand = " = ", bool isnum = false)
        {
            WhereFields.Add(new SQLWhereVar(con, field1, field2, operand, isnum));
        }
        public string GetSql()
        {
            string command = $"Update {TableName} SET { Utilities.RemoveLastComma(Variables.GetFieldOperandValueasStringorNum())}";
            if (WhereFields.Count() > 0)
                command += $" WHERE {Utilities.RemoveLastComma(WhereFields.GetFieldOperandValueasStringorNum())};";
            return command;
        }
        public string GetSqlWithParameters()
        {
            string command = $"Update {TableName} SET { Utilities.RemoveLastComma(Variables.GetFieldOperandParameter("@U"))}";
            if (WhereFields.Count() > 0)
                command += $" WHERE {Utilities.RemoveLastComma(WhereFields.GetWhereFieldEqualsParameter("@W"))};";
            return command;
        }
        public SQLParamList GetParamList()
        {
            SQLParamList temp = new SQLParamList();
            if (WhereFields.Count() > 0)
                temp.Add(WhereFields.GetParameterList("@W"));
            if (Variables.Count() > 0)
                temp.Add(Variables.GetParameterList("@U"));
            return temp;
        }
        public string GetMySql()
        {
            return GetSql();
        }
        public string GetMySqlWithParameters()
        {
            return GetSqlWithParameters();
        }
    }
}
