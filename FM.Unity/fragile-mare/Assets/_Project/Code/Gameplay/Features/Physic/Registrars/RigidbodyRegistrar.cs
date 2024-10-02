using _Project.Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physic.Registrars
{
    public class RigidbodyRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.AddRigidbody(GetComponentInChildren<Rigidbody>());
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveRigidbody();
        }
    }
}