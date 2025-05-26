using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Hancurkan peluru setelah 4 detik
        Destroy(gameObject, 4f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Cek apakah objek yang ditabrak memiliki tag bernama "Cube"
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Hancurkan kubus dan peluru
            Destroy(collision.gameObject); // Hancurkan kubus
            Destroy(gameObject); // Hancurkan peluru
        }
    }
}
