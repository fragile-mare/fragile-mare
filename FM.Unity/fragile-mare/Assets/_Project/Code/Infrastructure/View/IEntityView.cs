using UnityEngine;

namespace _Project.Code.Infrastructure.View
{
    public interface IEntityView
    {
        GameEntity Entity { get; }
        GameObject GameObject { get; }
        void SetEntity(GameEntity entity);
        void ReleaseEntity();
    }
}