using _Project.Code.Gameplay.Features.Camera.Zoom.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Camera.Zoom
{
    public class InputZoomFeature : Feature
    {
        public InputZoomFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputZoomPositionSystem>());
        }
    }
}