using System;
using System.Collections.Generic;
using System.Text;


namespace SQLSharp
{
    public class SQLVar
    {
        protected string Name;

        public SQLVar(string nm)
        {
            Name = nm;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string nm)
        {
            Name = nm;
        }
        public string GetAsParameter(string prefix="@")
        {
            return $"{prefix}{Name}";
        }
    }
}
