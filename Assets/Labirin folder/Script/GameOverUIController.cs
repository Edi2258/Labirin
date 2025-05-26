using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Transform playerCamera; // Referensi ke kamera player
    public float distanceFromCamera = 2.0f; // Jarak UI dari kamera player

    void Update()
    {
        PositionUIInFrontOfCamera();
    }

    void PositionUIInFrontOfCamera()
    {
        // Tentukan posisi UI di depan kamera
        Vector3 newPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;
        transform.position = newPosition;

        // Rotasi UI agar selalu menghadap ke arah kamera
        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.position);
    }
}
