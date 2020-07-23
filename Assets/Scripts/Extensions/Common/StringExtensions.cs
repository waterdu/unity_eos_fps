using System.Text.RegularExpressions;

namespace Oka.Common
{
    /// <summary>
    /// string extension
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Short IsNullOrEmpty
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>true:empty</returns>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// Not IsNullOrEmpty
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>true:true:not empty</returns>
        public static bool NotEmpty(this string s) => string.IsNullOrEmpty(s) == false;


        /// <summary>
        /// Convert byte
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="error">value at error</param>
        /// <returns>int</returns>
        public static byte ToByte(this string s, byte error = 0) => byte.TryParse(s, out byte result) ? result : error;

        /// <summary>
        /// Convert int
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="error">value at error</param>
        /// <returns>int</returns>
        public static int ToInt(this string s, int error = -1) => int.TryParse(s, out int result) ? result : error;

        /// <summary>
        /// Convert long
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="error">value at error</param>
        /// <returns>long</returns>
        public static long ToLong(this string s, long error = -1) => long.TryParse(s, out long result) ? result : error;

        /// <summary>
        /// Replace by regex
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="regex">Regex string</param>
        /// <param name="replace">Replace string</param>
        /// <returns>Replaced string</returns>
        public static string ReplaceAll(this string s, string regex, string replace) => Regex.Replace(s, regex, replace);

        /// <summary>
        /// Is match regex?
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="regex">Regex string</param>
        /// <returns>true:matched</returns>
        public static bool IsMatch(this string s, string regex) => Regex.IsMatch(s, regex);

        /// <summary>
        /// Null to empty
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>文字列または空文字</returns>
        public static string NullToEmp(this string s) => s == null ? string.Empty : s;
    }
}
