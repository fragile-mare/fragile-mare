using _Project.Code.Infrastructure;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class LevelDataProvider : ILevelDataProvider
    {
        private readonly Cached<Vector3> _startPoint;
        private readonly Cached<Quaternion> _startRotation;

        public LevelDataProvider()
        {
            _startRotation = new Cached<Quaternion>(() =>
            {
                var initialRotation = Quaternion.identity;

                var startPoint = GameObject.FindWithTag("StartPoint");
                if (startPoint != null)
                {
                    initialRotation = startPoint.transform.rotation;
                }

                return initialRotation;
            });

            _startPoint = new Cached<Vector3>(() =>
            {
                var initialPosition = Vector3.zero;

                var startPoint = GameObject.FindWithTag("StartPoint");
                if (startPoint != null)
                {
                    initialPosition = startPoint.transform.position;
                }

                return initialPosition;
            });
        }

        public Quaternion StartRotation => _startRotation.Value;
        public Vector3 StartPoint => _startPoint.Value;

        public void Refresh()
        {
            _startRotation.Invalidate();
            _startPoint.Invalidate();
        }
    }
}