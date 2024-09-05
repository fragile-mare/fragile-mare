using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using Entitas;

namespace _Project.Code.Gameplay.Input.Common.Systems
{
    public class InitializeInputSystem : IInitializeSystem, ITearDownSystem
    {
        private GameEntity _input;

        public void Initialize()
        {
            _input = CreateEntity.Empty()
                .With(x => x.isInput = true);
        }

        public void TearDown()
        {
            _input.Destroy();
        }
    }
}