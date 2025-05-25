using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float mouseSensitivity = 400f;
    public Transform orientation;

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // Apply the rotation to the camera  
        orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f); // Apply the horizontal rotation to the orientation
    }
}
