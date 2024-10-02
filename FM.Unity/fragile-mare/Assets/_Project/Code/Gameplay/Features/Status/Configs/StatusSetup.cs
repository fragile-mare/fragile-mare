using System;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Status.Configs
{
    [Serializable]
    public class StatusSetup
    {
        public StatusType type;
        public bool infinity;
        public float duration;
        public float value;
        public float radius;
        public Vector3 targetVelocity = Vector3.zero;
        public Vector3 deltaAxis = new(1, 1, 1);
    }
}