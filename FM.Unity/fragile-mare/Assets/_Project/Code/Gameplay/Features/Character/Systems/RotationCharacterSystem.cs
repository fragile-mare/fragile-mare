using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class RotationCharacterSystem : IExecuteSystem
    {
        private readonly ICameraProvider _camera;
        private readonly IGroup<GameEntity> _characters;

        public RotationCharacterSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _characters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Character,
                GameMatcher.Transform
            ));
        }

        public void Execute()
        {
            foreach (var character in _characters)
            {
                var cameraRotation = _camera.GetCameraRotationXYZ();
                var characterRotation = character.Transform.rotation;
                character.Transform.rotation = new Quaternion( characterRotation.x, cameraRotation.y, characterRotation.z, cameraRotation.w);
            }
        }
    }
}