using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverUI; // Referensi untuk UI Game Over


    public AudioSource source;
    public AudioClip fireSound;
    public AudioClip finishSound;

    void Start()
    {
       
        gameOverUI.SetActive(false); // Pastikan UI Game Over tidak aktif saat game dimulai
    }

   
    void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(fireSound);
        if (collision.gameObject.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Balok"))
        {
            source.PlayOneShot(finishSound);
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true); // Menampilkan UI Game Over
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Mengembalikan waktu normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Memuat ulang scene saat ini
    }

    public void ExitGame()
    {
        // Jika dijalankan di editor Unity, keluar dari mode play
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Jika dijalankan sebagai aplikasi standalone, keluar dari aplikasi
        Application.Quit();
#endif
    }
}
