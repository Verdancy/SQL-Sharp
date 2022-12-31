namespace SQLSharp
{
    public class SQLJoinFields
    {
        private string Field1;
        private string Field2;
        private string Operand;
        private string JoinType;
        /// <summary>
        /// This constructur creates the instance of the Join Fields to be used in the SQLJoinTable class
        /// </summary>
        /// <param name="one">This is a field from a table that will be matched to a second field</param>
        /// <param name="two">This is the second field that will match the one to create the join</param>
        /// <param name="operand">This is an operand for the join. Usually = </param>
        public SQLJoinFields(string one, string two, string jointype="", string operand = " = ")
        {
            Field1 = one;
            Field2 = two;
            Operand = operand;
            JoinType = jointype;
        }
        /// <summary>
        /// Returns the sql for the fields that are being joined.
        /// </summary>
        /// <returns></returns>
        public string GetJoinSQL()
        {
            return Field1 + Operand + Field2;
        }
        public string GetJoinType()
        {
            return JoinType;
        }
        public void MakeLeftJoin()
        {
            JoinType = "LEFT";
        }
        public void MakeInnerJoin()
        {
            JoinType = "INNER";
        }
        public void MakeCrossJoin()
        {
            JoinType = "CROSS";
        }
        public void MakeFullOuterJoin()
        {
            JoinType = "FULL OUTER";
        }
    }
}
