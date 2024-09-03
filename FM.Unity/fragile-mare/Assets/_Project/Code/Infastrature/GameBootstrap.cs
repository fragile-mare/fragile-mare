using System;
using UnityEngine;

namespace _Project.Code.Infastrature
{
    public class GameBootstrap : MonoBehaviour
    {
        public void Awake()
        {
            var game = new Game();
            game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}