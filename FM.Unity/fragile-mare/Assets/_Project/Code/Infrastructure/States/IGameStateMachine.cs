﻿namespace _Project.Code.Infrastructure
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}