using UnityEngine;

namespace Oka.Common
{
    /// <summary>
    /// Extension MonoBehaviour
    /// </summary>
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Get RectTransform
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <returns>RectTransform</returns>
        public static RectTransform GetRectTransform(this MonoBehaviour mono) => mono.transform as RectTransform;

        /// <summary>
        /// Switch gameObject active
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <param name="b">true:活性</param>
        /// <returns>RectTransform</returns>
        public static void SetActive(this MonoBehaviour mono, bool b) => mono.gameObject.SetActive(b);

        /// <summary>
        /// Get Transform Global Position 
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <returns>Global Position</returns>
        public static Vector3 GetPosition(this MonoBehaviour mono) => mono.transform.position;

        /// <summary>
        /// Set Transform Global Position 
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <param name="pos">Global Position</param>
        public static void SetPosition(this MonoBehaviour mono, Vector3 pos) => mono.transform.position = pos;

        /// <summary>
        /// Get Transform Global Rotation 
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <returns>Global Rotation</returns>
        public static Quaternion GetRotation(this MonoBehaviour mono) => mono.transform.rotation;

        /// <summary>
        /// Set Transform Global Rotation 
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <param name="rot">Global Rotation</param>
        public static void SetRotation(this MonoBehaviour mono, Quaternion rot) => mono.transform.rotation = rot;
    }
}