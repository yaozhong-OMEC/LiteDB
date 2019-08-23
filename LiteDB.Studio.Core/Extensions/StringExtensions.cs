namespace LiteDB.Studio.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static bool IsNotNullOrEmptyOrWhiteSpace(this string input)
        {
            return input.IsNotNullOrEmpty() && input.Trim() != string.Empty;
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == string.Empty;
        }
    }
}