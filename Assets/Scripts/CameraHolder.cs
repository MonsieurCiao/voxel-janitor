using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.position = cameraTransform.position;
    }
}
