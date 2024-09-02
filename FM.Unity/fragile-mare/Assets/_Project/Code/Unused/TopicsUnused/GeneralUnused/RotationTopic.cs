using System;
using _Project.Code.Unused.UtilsUnused.UnityTopicUnused;
using UnityEngine;

namespace _Project.Code.Unused.TopicsUnused.GeneralUnused
{
    [Obsolete("Unused.")]
    public class RotationTopic : UnityDynamicTopic<RotationParams>
    {
        public override string Suffix => ".rotation";
    }

    [Obsolete("Unused.")]
    public class RotationParams
    {
        public Quaternion Rotation;

        public override string ToString()
        {
            return $"RotationParams: Rotation {Rotation}.";
        }
    }
}