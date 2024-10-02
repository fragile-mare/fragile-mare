namespace _Project.Code.Gameplay.Input.Scroll.Services
{
    public class ScrollPositionService : IScrollPositionService
    {
        public float GetScrollPosition()
        {
            return UnityEngine.Input.GetAxis("Mouse ScrollWheel");
        }
    }
}