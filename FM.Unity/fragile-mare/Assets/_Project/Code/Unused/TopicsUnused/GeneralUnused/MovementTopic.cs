using System;
using _Project.Code.Unused.UtilsUnused.UnityTopicUnused;
using UnityEngine;

namespace _Project.Code.Unused.TopicsUnused.GeneralUnused
{
    [Obsolete("Unused.")]
    public class MovementTopic : UnityDynamicTopic<MovementParams>
    {
        public override string Suffix => ".movement";
    }

    [Obsolete("Unused.")]
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