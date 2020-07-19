using UnityEngine;

namespace Oka.Common
{
    /// <summary>
    /// PlayerPrefs wrapper
    /// </summary>
    public static class SaveDataUtils
    {
        /// <summary>
        /// Get string from PlayerPrefs
        /// </summary>
        /// <param name="k">key</param>
        /// <returns>saved string</returns>
        public static string GetString(string k) => PlayerPrefs.GetString(k, default);

        /// <summary>
        /// Save string to PlayerPrefs
        /// </summary>
        /// <param name="k">key</param>
        /// <param name="v">value</param>
        public static void SaveString(string k, string v)
        {
            PlayerPrefs.SetString(k, v);
            PlayerPrefs.Save();
        }
    }
}
