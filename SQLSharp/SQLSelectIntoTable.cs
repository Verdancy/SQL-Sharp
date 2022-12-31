using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    
    public class SQLSelectIntoTable:SQLJoinTable
    {
       string DestinationTable = "";
        string ExternalDB = "";
        public SQLSelectIntoTable(string nm):base(nm)
        {
        }
        public SQLSelectIntoTable(string nm, string destinationtable, string externaldb = ""):base(nm)
        {
            DestinationTable = destinationtable;
            ExternalDB = externaldb;
        }
        public SQLSelectIntoTable(SQLSelectTable table, string destinationtable="", string externaldb=""):base(table)
        {
            DestinationTable = destinationtable;
            ExternalDB = externaldb;
        }
        public SQLSelectIntoTable(string maintable, SQLVars selectfields, SQLWhereVars wherefields, string destinationtable="", string externaldb="") : base(maintable, selectfields, wherefields)
        {
            DestinationTable = destinationtable;
            ExternalDB = externaldb;
        }
        public SQLSelectIntoTable(string maintable, List<string> jointables, List<SQLJoinFields> joinfields, SQLVars selectfields, SQLWhereVars wherefields, string destinationtable="", string externaldb="") : base(maintable, jointables,joinfields, selectfields, wherefields)
        {
            DestinationTable = destinationtable;
            ExternalDB = externaldb;
        }
        public void SetDestinationTable(string destinationtable)
        {
            DestinationTable = destinationtable;
        }
        public void SetExternalDB(string externaldb)
        {
            ExternalDB = externaldb;
        }
        public void SetDestination(string destinationtable, string externaldb)
        {
            DestinationTable = destinationtable;
            ExternalDB = externaldb;
        }
        public string GetINTO()
        {
            string command = $" INTO {DestinationTable}";
            if (!(ExternalDB.Equals("")))
                command += $" IN {ExternalDB}";
            return command;
            
        }
        new protected string GetSelectFrom()
        {
            return $"SELECT {GetDistinct()} {SelectFields.GetFieldNames()} {GetINTO()} FROM {MainTable}";
        }
        public override string GetSql()
        {
            return $"{GetSelectFrom()}{GetWhere()}{GetGroupBy()}{GetHaving()}{GetOrderBy()};";
        }
        public override string GetMySql()
        {
            return GetSql();
        }
        
    }
}
