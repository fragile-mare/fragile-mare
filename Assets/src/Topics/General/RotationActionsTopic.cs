using src.Utils.UnityTopic;
using UnityEngine;

namespace src.Topics.General
{
    public class RotationActionsTopic : UnityDynamicTopic<Quaternion>
    {
        public override string Suffix => "rotation.actions";
    }
}