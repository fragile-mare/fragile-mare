using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.TransformPosition
{
    public class ListenWorldPositionForRigidbodySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidBodies;

        public ListenWorldPositionForRigidbodySystem(GameContext game)
        {
            _rigidBodies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rigidbody,
                    GameMatcher.WorldPosition)
                .NoneOf(GameMatcher.ForceMovePosition));
        }

        public void Execute()
        {
            foreach (GameEntity body in _rigidBodies)
            {
                body.ReplaceWorldPosition(body.Rigidbody.position);
            }
        }
    }
}