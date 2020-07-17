using Object = UnityEngine.Object;

namespace Oka.Common
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Destroy if not null
        /// </summary>
        /// <param name="o">Object</param>
        public static void DestroyNotNull(this Object o)
        {
            if (o != null)
            {
                Object.Destroy(o);
            }
        }
    }
}
