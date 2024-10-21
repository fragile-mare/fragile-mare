using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.StaticData;
using _Project.Code.Gameplay.Input.Controls.Services;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Common.Systems
{
    public class InitializeInputSystem : IInitializeSystem, ITearDownSystem
    {
        private GameEntity _input;
        private readonly IStaticDataService _staticData;
        private readonly IDefaultControlsProvider _controls;

        public InitializeInputSystem(IStaticDataService staticData, IDefaultControlsProvider controls)
        {
            _staticData = staticData;
            _controls = controls;
        }
        
        public void Initialize()
        {
            _input = CreateEntity.Empty()
                .With(x => x.isInput = true)
                .AddXRotationCursor(0)
                .AddYRotationCursor(0)
                .AddCursorX(0)
                .AddCursorY(0)
                .AddMouseSens(_staticData.InputConfig.mouseSens)
                .AddZoom(_staticData.InputConfig.zoom)
                .AddZoomMin(_staticData.InputConfig.minZoom)
                .AddZoomMax(_staticData.InputConfig.maxZoom)
                .AddOffset(Vector3.zero)
                .AddMouseScrollWheel(0)
                .AddLimitRotationY(_staticData.InputConfig.rotationYLimit);
            
            _input.AddControls(_controls.GetDefaultControlsCopy());
        }

        public void TearDown()
        {
            _input.Destroy();
        }
    }
}