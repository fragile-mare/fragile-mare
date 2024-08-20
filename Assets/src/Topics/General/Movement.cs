using src.Utils.UnityTopic;
using UnityEngine;

namespace src.Topics.General
{
    public class Movement : UnityStaticTopic<MovementParams>
    {
        protected override string TopicName => "general.movement";
    }

    public class MovementParams
    {
        public Vector3 Move;
        public Vector3 OldPosition;

        public override string ToString()
        {
            return $"MovementParams: Move {Move}."; //, OldPosition {OldPosition}.";
        }
    }
    
}