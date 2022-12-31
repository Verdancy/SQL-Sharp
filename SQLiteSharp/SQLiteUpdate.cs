using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using SQLSharp;


namespace SQLiteSharp
{
    public class SQLiteUpdate
    {
        private bool Success = false;
        private string CommandPerformed = "";
        private string SQLPerformed = "";

        public SQLiteUpdate(SQLiteConnection sqlcon, SQLUpdateTable table)
        {
            DoUpdateCommand(sqlcon, table);//.GetSQL());
        }
        public SQLiteUpdate(SQLiteConnection sqlcon, string TableName, SQLVarsVals Fields, SQLWhereVars WhereFields)
        {
            SQLUpdateTable table = new SQLUpdateTable(TableName, Fields, WhereFields);
            DoUpdateCommand(sqlcon, table);
        }
        public SQLiteUpdate(SQLiteConnection sqlcon, string TableName, SQLVarVal Field, SQLWhereVar WhereFields)
        {
            SQLUpdateTable table = new SQLUpdateTable(TableName, Field, WhereFields);
            DoUpdateCommand(sqlcon, table);
        }
        public SQLiteUpdate(SQLiteConnection sqlcon, string sqlcommand)
        {
            DoUpdateCommand(sqlcon, sqlcommand);
        }
        private void DoUpdateCommand(SQLiteConnection sqlcon, SQLUpdateTable table)
        {
            CommandPerformed = $"{table.GetSqlWithParameters()}{Environment.NewLine}{table.GetParamList().ToString()}";
            SQLPerformed = table.GetSql();
            try
            {
                SqliteConnection db = sqlcon.GetConnection();
                using (SqliteCommand command = db.CreateCommand())
                {
                    command.CommandText = table.GetSqlWithParameters();
                    List<SqliteParameter> Params = GetCommandParameters(table.GetParamList());
                    if (Params.Count > 0)
                    {
                        foreach (var p in Params)
                        {
                            command.Parameters.Add(p);
                        }
                    }
                    command.ExecuteNonQuery();
                }
                Success = true;
            }
            catch
            {
                Success = false;
            }
        }
        private void DoUpdateCommand(SQLiteConnection sqlcon, string commandtext)
        {
            CommandPerformed = commandtext;
            SQLPerformed = commandtext;
            try
            {
                SqliteConnection db = sqlcon.GetConnection();
                using (var command = db.CreateCommand())
                {
                    command.CommandText = commandtext;
                    command.ExecuteNonQuery();
                }
                Success = true;
            }
            catch
            {
                Success = false;
            }
        }
        private List<SqliteParameter> GetCommandParameters(SQLParamList Params)
        {
            List<SqliteParameter> param = new List<SqliteParameter>();
            for (int index = 0; index < Params.Count(); index++)
                param.Add(new SqliteParameter(Params.GetParameter(index), Params.GetValue(index)));
            return param;
        }
        public bool GetSuccess()
        {
            return Success;
        }
        public string GetCommmandPerformed()
        {
            return CommandPerformed;
        }
        public string GetSQLPerfomed()
        {
            return SQLPerformed;
        }
    }
}
