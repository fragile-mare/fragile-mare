using _Project.Code.Common.Entity;
using Entitas;

namespace _Project.Code.Gameplay.Input.Systems
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .isInput = true;
        }
    }
}