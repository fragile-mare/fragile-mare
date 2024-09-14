using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class LevelDataProvider : ILevelDataProvider
    {
        private Vector3 _startPoint = Vector3.zero;
        private Quaternion _startRotation = Quaternion.identity;
        
        public Quaternion StartRotation { get; }
        public Vector3 StartPoint { get; }

        public void SetStartPoint(Vector3 startPoint)
        {
            _startPoint = startPoint;
        }

        public void SetStartRotation(Quaternion startRotation)
        {
            _startRotation = startRotation;
        }
    }
}