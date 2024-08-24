using System.Collections;
using System.Collections.Generic;
using src.Topics.General;
using src.Topics.Player;
using UnityEngine;

public class PlayerRotationByMouse : MonoBehaviour
{
    
    [SerializeField] private Camera playerCamera;

    [SerializeField] private Transform playerTransform;
    
    [SerializeField] 
    private float rotationSpeed = 1000f;
    
    private Vector3 _oldRotation = Vector3.zero;
    
    void Start()
    {
        if (playerCamera == null) playerCamera = Camera.main;
    }
    
    void Update()
    {
        var mouseRotation = Input.mousePosition;
        if (_oldRotation == mouseRotation) return;
        
        // playerTransform.eulerAngles = @params.Rotation;
        // playerTransform.Rotate(@params.Rotation);
        // if (UnityEngine.Camera.main != null)
        // {
        //     playerTransform.rotation =
        //         Quaternion.LookRotation(UnityEngine.Camera.main.ScreenToWorldPoint(@params.Rotation));
        // }
        
        var positionOnScreen = (Vector2) playerCamera.WorldToViewportPoint(playerTransform.position);
        var mouseOnScreen = (Vector2) playerCamera.ScreenToViewportPoint(mouseRotation);
		
        var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        _oldRotation = mouseRotation;
        
        var rot = playerTransform.rotation;
        var wantedRotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        
        playerTransform.rotation = Quaternion.RotateTowards(rot, wantedRotation, Time.deltaTime * rotationSpeed);
        
        PlayerRotation.Publish(new RotationParams
        {
            Rotation = playerTransform.eulerAngles
        });
    }
    
    private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
