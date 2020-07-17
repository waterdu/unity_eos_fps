using  UnityEngine;

namespace Oka.Common
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Destroy if not null
        /// </summary>
        /// <param name="go">GameObject</param>
        public static void DestroyNotNull(this GameObject go)
        {
            if (go != null)
            {
                Object.Destroy(go);
            }
        }
    }
}
