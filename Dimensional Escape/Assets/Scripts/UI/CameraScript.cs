using UnityEngine;

public class CameraScript: MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 2, -5);
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Desired position based on target's position and offset
        Vector3 desiredPosition = target.position + 
                                  target.right * offset.x + 
                                  Vector3.up * offset.y + 
                                  target.forward * offset.z;
        
        // Smoothly move the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Look at target
        transform.LookAt(target.position + Vector3.up);
    }
    
}
