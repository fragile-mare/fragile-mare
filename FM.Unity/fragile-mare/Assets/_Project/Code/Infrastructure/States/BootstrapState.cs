using UnityEngine.SceneManagement;

namespace _Project.Code.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Desert = "Desert";

        public void Enter()
        {
            SceneManager.LoadScene(Desert);
        }

        public void Exit()
        {
            
        }
    }
}