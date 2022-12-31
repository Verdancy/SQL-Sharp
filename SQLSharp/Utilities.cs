using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSharp
{
    public static class Utilities
    {
        public static string RemoveLastComma(string value)
        {
            int index = value.LastIndexOf(',');
            if (index > 0)
                value = value.Remove(index);
            return value;
        }
        public static string RemoveLastCommaAddPar(string value)
        {
            int index = value.LastIndexOf(',');
            if (index > 0)
                value = value.Remove(index) + ")";
            return value;
        }
    }
}
