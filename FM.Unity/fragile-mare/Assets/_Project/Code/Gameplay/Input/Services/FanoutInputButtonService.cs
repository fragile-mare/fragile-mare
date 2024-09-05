namespace _Project.Code.Gameplay.Input.Services
{
    public class FanoutInputButtonService : IInputButtonService
    {
        private readonly IInputButtonService _service1;
        private readonly IInputButtonService _service2;

        public FanoutInputButtonService(IInputButtonService service1, IInputButtonService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        public bool IsSprintPressed()
        {
            return _service1.IsSprintPressed() || _service2.IsSprintPressed();
        }

        public bool IsDashPressed()
        {
            return _service1.IsDashPressed() || _service2.IsDashPressed();
        }
    }
}