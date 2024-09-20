using UnityEngine;

namespace _Project.Code.Common.Exit
{
    public class ExitGame : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        }
    }
}