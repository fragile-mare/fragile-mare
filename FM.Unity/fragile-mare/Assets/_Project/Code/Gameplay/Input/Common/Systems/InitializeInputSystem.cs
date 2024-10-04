using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.StaticData;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Common.Systems
{
    public class InitializeInputSystem : IInitializeSystem, ITearDownSystem
    {
        private GameEntity _input;
        private readonly IStaticDataService _staticData;
        
        public InitializeInputSystem(IStaticDataService staticData)
        {
            _staticData = staticData;
        }
        
        public void Initialize()
        {
            _input = CreateEntity.Empty()
                .With(x => x.isInput = true)
                .AddXRotationCursor(0)
                .AddYRotationCursor(0)
                .AddCursorX(0)
                .AddCursorY(0)
                .AddMouseSens(1)
                .AddZoom(0.25f)
                .AddZoomMin(3)
                .AddZoomMax(10)
                .AddOffset(Vector3.zero)
                .AddMouseScrollWheel(0)
                .AddLimitRotationY(80);
        }

        public void TearDown()
        {
            _input.Destroy();
        }
    }
}