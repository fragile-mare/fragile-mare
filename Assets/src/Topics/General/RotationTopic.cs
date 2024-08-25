using src.Utils.UnityTopic;
using UnityEngine;

namespace src.Topics.General
{
    public class RotationTopic : UnityDynamicTopic<RotationParams>
    {
        public override string Suffix => ".rotation";
    }

    public class RotationParams
    {
        public Quaternion Rotation;

        public override string ToString()
        {
            return $"RotationParams: Rotation {Rotation}.";
        }
    }
}