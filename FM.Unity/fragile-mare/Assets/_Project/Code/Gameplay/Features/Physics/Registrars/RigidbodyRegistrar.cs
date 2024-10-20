using _Project.Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics.Registrars
{
    public class RigidbodyRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.AddRigidbody(GetComponentInChildren<Rigidbody>());
            Entity.AddVelocity(Entity.Rigidbody.velocity);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveRigidbody();
        }
    }
}