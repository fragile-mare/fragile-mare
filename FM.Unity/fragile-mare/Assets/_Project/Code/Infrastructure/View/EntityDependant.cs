using UnityEngine;

namespace _Project.Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        public IEntityView EntityView;
        public GameEntity Entity => EntityView != null ? EntityView.Entity : null;

        private void Awake()
        {
            if (EntityView == null)
                EntityView = GetComponent<IEntityView>();
        }
    }
}