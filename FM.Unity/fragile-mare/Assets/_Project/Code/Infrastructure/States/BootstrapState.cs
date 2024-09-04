﻿using UnityEngine.SceneManagement;

namespace _Project.Code.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        public void Enter()
        {
            SceneManager.LoadScene(Initial);
        }

        public void Exit()
        {
            
        }
    }
}