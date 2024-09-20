using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
