using UnityEngine;

namespace Oka.Common
{
    /// <summary>
    /// Vector3 extension
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Set x
        /// </summary>
        /// <param name="vec">Vector3</param>
        /// <param name="y">y</param>
        /// <returns>Vector3</returns>
        public static Vector3 SetX(this Vector3 vec, float x)
        {
            vec.x = x;
            return vec;
        }

        /// <summary>
        /// Set y
        /// </summary>
        /// <param name="vec">Vector3</param>
        /// <param name="y">y</param>
        /// <returns>Vector3</returns>
        public static Vector3 SetY(this Vector3 vec, float y)
        {
            vec.y = y;
            return vec;
        }
    }
}
