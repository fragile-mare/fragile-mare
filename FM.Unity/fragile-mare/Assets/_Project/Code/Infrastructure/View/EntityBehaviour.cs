using _Project.Code.Common.Services.Collisions;
using _Project.Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace _Project.Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;
        public GameEntity Entity => _entity;
        public GameObject GameObject => gameObject;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry) =>
            _collisionRegistry = collisionRegistry;


        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();

            foreach (Collider collider in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents();

            foreach (Collider collider in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Unregister(collider.GetInstanceID());

            _entity.Release(this);
            _entity = null;
        }
    }
}