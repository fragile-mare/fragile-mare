using UnityEngine;

namespace _Project.Code.Common.Services.Assets
{
  public interface IAssetProvider
  {
    GameObject LoadAsset(string path);
    T LoadAsset<T>(string path) where T : Component;
  }
}