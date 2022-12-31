using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public class SQLOrderVar:SQLVar
    {
        string Order = "ASC";

        public SQLOrderVar(string nm, string order) : base(nm)
        {
            Order = order;
        }
        public void MakeASC()
        {
            Order = "ASC";
        }
        public void MakeDESC()
        {
            Order = "DESC";
        }
        public string GetOrder()
        {
            return Order;
        }
        public void SetOrder(string order)
        {
            Order = order;
        }

    }
}
