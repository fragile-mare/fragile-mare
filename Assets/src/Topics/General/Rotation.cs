using src.Utils.UnityTopic;
using UnityEngine;

namespace src.Topics.General
{
    public class Rotation : UnityStaticTopic<RotationParams>
    {
        protected override string TopicName => "general.rotation";
    }

    public class RotationParams
    {
        public Vector3 Rotation;

        public override string ToString()
        {
            return $"RotationParams: Rotation {Rotation}.";
        }
    }
}