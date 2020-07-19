using System.Collections.Generic;

namespace Oka.Common
{
    /// <summary>
    /// Dictionary extension
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Whether there is  key
        /// </summary>
        /// <typeparam name="T">Key Type</typeparam>
        /// <typeparam name="_">Value Type</typeparam>
        /// <param name="dic">Dictionary</param>
        /// <param name="key">Key</param>
        /// <returns>true: not exists key</returns>
        public static bool NoKey<T, _>(this Dictionary<T, _> dic, T key) => dic.ContainsKey(key) == false;
    }
}
