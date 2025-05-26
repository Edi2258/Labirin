using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torso : MonoBehaviour
{
    public Transform vrCamera; // Reference to the VR camera
    public Vector3 offset = new Vector3(0f, -0.5f, 0f); // Offset to position the "Torso" under the camera

    private void Start()
    {
        if (vrCamera == null)
        {
            // If the VR camera reference is not assigned, try to find it by tag
            vrCamera = Camera.main.transform; // Assuming your VR camera is tagged as "MainCamera"
        }
    }

    private void Update()
    {
        if (vrCamera != null)
        {
            // Calculate the desired position for the "Torso" based on the offset
            Vector3 targetPosition = vrCamera.position + vrCamera.TransformDirection(offset);

            // Set the position and rotation of the "Torso" to match the VR camera
            transform.position = targetPosition;
            transform.rotation = vrCamera.rotation;
        }
        else
        {
            Debug.LogWarning("VR Camera not found. Please assign the VR camera reference.");
        }
    }
}
