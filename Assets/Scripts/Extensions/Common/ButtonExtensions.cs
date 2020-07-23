using UnityEngine.UI;
using UnityEngine.Events;

namespace Oka.Common
{
    /// <summary>
    /// TMP_InputField Extensions
    /// </summary>
    public static class ButtonExtensions
    {
        /// <summary>
        /// Set onClick Action
        /// </summary>
        /// <param name="button">button</param>
        /// <param name="act">action at click</param>
        public static void SetOnClick(this Button button, UnityAction act)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(act);
        }
    }
}