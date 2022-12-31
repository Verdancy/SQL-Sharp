using System;
using Microsoft.Data.Sqlite;
using System.Data.Common;


namespace SQLiteSharp
{    
    public class SQLiteConnection
    {        
        SqliteConnection dbc;       
        
        /// <summary>
        /// This constructor establishes an in memory SQLite database connection
        /// </summary>
        public SQLiteConnection()   
        {
            string connectionString = "Data Source=:memory:";
            dbc = new SqliteConnection(connectionString);
        }
        /// <summary>
        /// This constructor establishes a SQLite database on the file system 
        /// </summary>
        /// <param name="filename">The name of the SQLite datafile to store the db for permanent access and updating</param>
        public SQLiteConnection(string filename)
        {
            string connectionString = $"Data Source={filename}";
            dbc = new SqliteConnection(connectionString);
        }
        /// <summary>
        /// //This returns the connection to the SQLite database for writing and reading to it
        /// </summary>
        /// <returns>DBCOnnection to the SQLite db</returns>
        public SqliteConnection GetConnection()
        {      
           
            dbc.Open();
            return dbc;
        }
        /// <summary>
        /// //This closes the connection to the SQLite database
        /// </summary>
        public void Close()
        {
            dbc.Close();
        }
        /// <summary>
        /// to do save in memory to file
        /// </summary>
        /// <param name="fileName"></param>
        //public void save(string fileName)
        //{
           
        //}
        
    }
}
