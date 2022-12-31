using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using SQLSharp;


namespace SQLiteSharp
{
    public class SQLiteDelete
    {
        private bool Success = false;
        private string CommandPerformed = "";
        private string SQLPerformed = "";

        /// <summary>
        /// Constructor that takes the database connection and the delete table that contains the information for the command 
        /// </summary>
        /// <param name="sqlcon"></param>
        /// <param name="table"></param>
        public SQLiteDelete(SQLiteConnection sqlcon, SQLDeleteTable table)
        {
            DoDeleteCommand(sqlcon, table);
        }
        /// <summary>
        /// Constructor with the database connection and a string that contains the SQL statement that needs to be done.
        /// </summary>
        /// <param name="sqlcon"></param>
        /// <param name="command"></param>
        public SQLiteDelete(SQLiteConnection sqlcon, string command)
        {
            DoDeleteCommand(sqlcon, command);
        }
        /// <summary>
        /// Constructor that takes the table name, there where values that are to be used delete the matching records. It can also take a bool value to delete everything
        /// </summary>
        /// <param name="sqlcon"></param>
        /// <param name="TableName"></param>
        /// <param name="WhereFields"></param>
        /// <param name="deleteallrecords"></param>
        public SQLiteDelete(SQLiteConnection sqlcon, string TableName, SQLWhereVars WhereFields, bool deleteallrecords = false)
        {
            SQLDeleteTable table = new SQLDeleteTable(TableName, WhereFields, deleteallrecords);
            DoDeleteCommand(sqlcon, table);
        }
        private void DoDeleteCommand(SQLiteConnection sqlcon, string commandtext)
        {
            CommandPerformed = commandtext;
            SQLPerformed = commandtext;
            try
            {
                if (commandtext != "")
                {
                    SqliteConnection db = sqlcon.GetConnection();
                    using (var command = db.CreateCommand())
                    {
                        command.CommandText = commandtext;
                        command.ExecuteNonQuery();
                    }
                }
                Success = true;
            }
            catch
            {
                Success = false;
            }
        }
        private void DoDeleteCommand(SQLiteConnection sqlcon, SQLDeleteTable table)
        {
            CommandPerformed = $"{table.GetSqlWithParameters()}{Environment.NewLine}{table.GetParamList().ToString()}{Environment.NewLine}";
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
                    Success = true;
                }
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
