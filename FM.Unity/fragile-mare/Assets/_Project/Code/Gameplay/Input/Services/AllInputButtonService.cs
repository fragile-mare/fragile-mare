namespace _Project.Code.Gameplay.Input.Services
{
    public class AllInputButtonService : IInputButtonService
    {
        private readonly FanoutInputButtonService _service;

        public AllInputButtonService()
        {
            var desktop = new DesktopInputButtonService();
            var gamepad = new GamepadInputButtonService();
            
            _service = new FanoutInputButtonService(desktop, gamepad);
        }


        public bool IsSprintPressed()
        {
            return _service.IsSprintPressed();
        }

        public bool IsDashPressed()
        {
            return _service.IsDashPressed();
        }
    }
}