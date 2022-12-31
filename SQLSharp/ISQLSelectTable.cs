namespace SQLSharp
{
    public interface ISQLSelectTable
    {
        SQLParamList GetParamList();
        string GetSqlWithParameters();
        string GetSql();
    }
}
