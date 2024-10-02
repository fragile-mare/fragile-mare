using _Project.Code.Gameplay.Features.Camera.Rotation;
using _Project.Code.Gameplay.Features.Camera.Zoom;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Camera
{
    public class CameraFeature : Feature
    {
        public CameraFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputZoomFeature>());
            Add(systems.Create<InputRotationFeature>());
        }
    }
}