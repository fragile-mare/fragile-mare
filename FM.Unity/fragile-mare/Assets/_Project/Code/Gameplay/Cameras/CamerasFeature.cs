using _Project.Code.Gameplay.Cameras.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Cameras
{
    public class CamerasFeature : Feature
    {
        public CamerasFeature(ISystemsFactory systems)
        {
            Add(systems.Create<CameraFollowCharacter>());
        }
    }
}