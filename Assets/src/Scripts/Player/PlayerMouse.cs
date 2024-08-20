using System.Collections;
using System.Collections.Generic;
using src.Topics.General;
using src.Topics.Player;
using UnityEngine;

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
