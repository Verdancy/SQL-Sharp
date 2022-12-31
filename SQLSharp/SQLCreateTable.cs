using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLCreateTable
    {
        private string TableName;
        private List<SQLField> Fields = new List<SQLField>();

        /// <summary>
        /// Constructor that allows the naming of a potential table
        /// </summary>
        /// <param name="nm">The name to give the table</param>
        public SQLCreateTable(string nm)
        {
            TableName = nm;
            Fields = new List<SQLField>();
        }
        /// <summary>
        /// A constructor to begin setting up a table with a list of Fields
        /// </summary>
        /// <param name="nm">The name to give the table</param>
        /// <param name="fds">Variable that contains the fields for the table.</param>
        public SQLCreateTable(string nm, List<SQLField> fds) : this(nm)
        {
            Fields = fds;
        }
        /// <summary>
        /// Adds a field to the table
        /// </summary>
        /// <param name="field">Contains all the information for the field to be added</param>
        public void AddField(SQLField field)
        {
            Fields.Add(field);
        }
        /// <summary>
        /// Adds a field to the table
        /// </summary>
        /// <param name="fname">The name of the field</param>
        /// <param name="ftype">The type of the field</param>
        /// <param name="len">The length of the field</param>
        /// <param name="cannull">Bool that indicates if the field can be nulled</param>
        /// <param name="auto">bool that indicates if the field should be autoincremented</param>
        /// <param name="isprimary">bool that indidcates if the field is the primary key</param>
        public void AddField(string fname, string ftype, int len = 0, bool cannull = false, bool auto = false, bool isprimary = false)
        {
            Fields.Add(new SQLField(fname, ftype, len, cannull, auto, isprimary));
        }
        /// <summary>
        /// Creates the SQL to create the table based on the table name and the fields that have been added
        /// </summary>
        /// <returns>returns the SQL statement that creates the table</returns>
        public string GetSql()
        {
            string commandtext = $"CREATE TABLE IF NOT EXISTS {TableName} (";
            for (int index = 0; index < Fields.Count; index++)
            {
                commandtext += Fields[index].GetSql();
            }
            commandtext = Utilities.RemoveLastCommaAddPar(commandtext) + ";";
            return commandtext;
        }
        public string getMySql()
        { 
            return GetSql();
        }
        
    }
}
