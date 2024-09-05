using UnityEngine;

namespace _Project.Code.Common.Extensions
{
    public static class TransformExtensions
    {
        public static Transform SetWorldXZ(this Transform transform, float x, float z)
        {
            transform.position = new Vector3(x, transform.position.y, z);
            return transform;
        }
    }
}