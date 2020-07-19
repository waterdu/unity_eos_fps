using System.Runtime.InteropServices;

namespace Oka.Common
{
    /// <summary>
    /// Marshal Tools 
    /// </summary>
    public static class MarshalTools
    {

        /// <summary>
        /// Serialize
        /// </summary>
        /// <typeparam name="T">Struct</typeparam>
        /// <param name="data">data</param>
        /// <returns>byte array</returns>
        public static byte[] Serialize<T>(T data)
            where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var array = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, ptr, true);
            Marshal.Copy(ptr, array, 0, size);
            Marshal.FreeHGlobal(ptr);
            return array;
        }

        /// <summary>
        /// Desirialize 
        /// </summary>
        /// <typeparam name="T">Struct</typeparam>
        /// <param name="bytes">bytes</param>
        /// <returns>struct</returns>
        public static T Deserialize<T>(byte[] bytes)
            where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            var s = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            return s;
        }
    }
}
