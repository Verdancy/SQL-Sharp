using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLAlterTable
    {
        string MainTable;
        string ModifyColumnName;
        string ActionToPerform;
        string DataType;
        string NewColumnName;
        string NewTableName;

        public SQLAlterTable(string table)
        {
            MainTable = table;
        }
        public SQLAlterTable(string table, string column) : this(table)
        {
            ModifyColumnName = column;
        }
        public SQLAlterTable(string table, string column, string action) : this(table, column)
        {
            ActionToPerform = action.ToUpper();
        }
        public SQLAlterTable(string table, string column, string action, string newtype) : this(table, column, action)
        {
            DataType = newtype;
        }
        public void MakeAdd()
        {
            ActionToPerform = "ADD";
        }
        public void MakeDrop()
        {
            ActionToPerform = "DROP";
        }
        public void MakeAlter()
        {
            ActionToPerform = "ALTER";
        }
        public void MakeRenameTable()
        {
            ActionToPerform = "RENAMETABLE";
        }
        public void SetNewDataType(string newtype)
        {
            DataType = newtype;
        }
        public void SetNewColumnName(string newname)
        {
            NewColumnName = newname;
        }
        public void SetNewTableName(string newname)
        {
            NewTableName = newname;
        }
      
        protected string GetAlterTable()
        {
            return $"ALTER TABLE {MainTable}";
        }
        protected string GetAction()
        {
            if (ActionToPerform.Equals("ADD"))
                return $"ADD {ModifyColumnName} {DataType}";
            else if (ActionToPerform.Equals("DROP"))            
                return $"DROP COLUMN {ModifyColumnName}";            
            else if (ActionToPerform.Equals("ALTER"))
                return $"ALTER COLUMN {ModifyColumnName} {DataType}";
            else if (ActionToPerform.Equals("RENAMETABLE"))
                return $"RENAME TO {NewTableName}";
            else
            {
                string action = $"{ActionToPerform} {ModifyColumnName}";
                if (!(DataType.Equals("")))
                    action += DataType;
                return action;
            }
        }
        protected string GetMySqlAction()
        {
            if (ActionToPerform.Equals("ADD"))
                return $"ADD {ModifyColumnName} {DataType}";
            else if (ActionToPerform.Equals("DROP"))
                return $"DROP COLUMN {ModifyColumnName}";
            else if (ActionToPerform.Equals("RENAMECOLUMN"))
                return $"CHANGE COLUMN {ModifyColumnName} {NewColumnName}";
            else if (ActionToPerform.Equals("ALTER"))
                return $"MODIFY COLUMN {ModifyColumnName} {DataType}";
            else if (ActionToPerform.Equals("RENAMETABLE"))
                return $"RENAME TO {NewTableName}";
            else
            {
                string action = $"{ActionToPerform} {ModifyColumnName}";
                if (!(DataType.Equals("")))
                    action += DataType;
                return action;
            }
        }
        public string GetSql()
        {
            return $"{GetAlterTable()} {GetAction()};";
        }
        public string GetMySql()
        {
            return $"{GetAlterTable()} {GetMySqlAction()};";
        }
    }
}
