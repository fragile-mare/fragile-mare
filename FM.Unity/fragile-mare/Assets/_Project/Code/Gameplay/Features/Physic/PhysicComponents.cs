using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physic
{
    [Game]
    public class RigidbodyComponent : IComponent
    {
        public Rigidbody Value;
    }

    [Game]
    public class ForceMovePosition : IComponent
    {
    }
}