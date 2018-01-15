namespace CSharp70.UseOutVariablesInMethodInvocations
{
    static class OutClass
    {
        public static bool Method(int i, out int j, ref int l)
        {
            j = 0;
            l = 0;
            return true;
        }

        public static bool Method(int i, out int j)
        {
            j = 0;
            return true;
        }
    }
}