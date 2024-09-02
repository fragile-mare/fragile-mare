using System;
using UnityEngine;

namespace _Project.Code.Unused.ScriptsUnused.PlayerUnused
{
    [Obsolete("Unused.")]
    public class PlayerMouse : MonoBehaviour
    {
        private Vector3 _oldRotation = Vector3.zero;
    
        void Update()
        {
            // var mouseRotation = Input.mousePosition; //new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            // if (_oldRotation == mouseRotation) return;
            //
            // _oldRotation = mouseRotation;
            // PlayerRotation.Publish(new RotationParams
            // {
            //     Rotation = mouseRotation
            // });
        }
    }
}
