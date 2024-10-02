using System;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        public EffectType type;
        public float value;
        public Vector3 direction;
    }
}