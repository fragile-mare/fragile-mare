namespace _Project.Code.Gameplay.Input.Axis.Services.Mouse
{
    public class ScrollPositionService : IScrollPositionService
    {
        public float GetScrollPosition()
        {
            return UnityEngine.Input.GetAxis("Mouse ScrollWheel");
        }
    }
}