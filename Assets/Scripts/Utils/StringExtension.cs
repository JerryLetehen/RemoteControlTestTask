namespace Game.Utils
{
    public static class StringExtension
    {
        public static bool Equals(this string a, string b)
        {
            if (a == null != (b == null))
            {
                return false;
            }

            return a == null || a.Equals(b);
        }
    }
}