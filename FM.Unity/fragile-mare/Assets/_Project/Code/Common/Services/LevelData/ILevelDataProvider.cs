using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public interface ILevelDataProvider
    {
        public Quaternion StartRotation { get; }
        public Vector3 StartPoint { get; }
        public void SetStartPoint(Vector3 startPoint);
        public void SetStartRotation(Quaternion startRotation);
    }
}