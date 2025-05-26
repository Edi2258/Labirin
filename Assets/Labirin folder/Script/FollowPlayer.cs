using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Referensi ke Transform pemain
    public float speed = 5f; // Kecepatan mengikuti

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Membekukan rotasi pada sumbu X dan Z untuk mencegah kubus terbalik
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Hitung arah menuju pemain
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Menjaga agar kubus tetap di sumbu Y yang sama

            // Mengatur orientasi kubus agar menghadap ke pemain
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                rb.rotation = Quaternion.Lerp(rb.rotation, toRotation, Time.deltaTime * speed);
            }

            // Pindahkan kubus menuju pemain dengan kecepatan tertentu
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Mencegah kubus melayang dengan menjaga posisinya tetap di tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector3 position = transform.position;
            position.y = collision.contacts[0].point.y + transform.localScale.y / 2;
            transform.position = position;
        }
    }
}
