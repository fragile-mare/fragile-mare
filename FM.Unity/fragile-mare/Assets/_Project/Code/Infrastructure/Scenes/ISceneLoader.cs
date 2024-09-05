using System;

namespace _Project.Code.Infrastructure.Scenes
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}