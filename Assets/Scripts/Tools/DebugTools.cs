using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Oka.Common
{
    /// <summary>
    /// Debug Tools 
    /// /// </summary>
    public static class DebugTools
    {
        /// <summary>
        /// Get class and method names
        /// </summary>
        /// <returns>class,method name</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetClassMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return $"{sf.GetMethod().DeclaringType}.{sf.GetMethod().Name}";
        }
    }
}
