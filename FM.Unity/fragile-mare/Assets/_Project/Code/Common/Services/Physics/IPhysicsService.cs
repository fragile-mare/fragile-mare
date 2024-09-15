using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Common.Services.Physics
{
  /// <summary>
  /// Сервис для связи мира Unity с миром ECS
  /// Нужен для получения Entity по коллайдерам
  /// </summary>
  public interface IPhysicsService
  {
    GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask);
    GameEntity LineCast(Vector3 start, Vector3 end, int layerMask);
    IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
    IEnumerable<GameEntity> SphereCast(Vector3 position, float radius, int layerMask);
    int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
    int SphereCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
  }
}