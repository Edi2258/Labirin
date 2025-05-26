using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnPrefab; // Prefab musuh yang akan di-spawn
    public Transform[] spawnLocations; // Array lokasi spawn musuh
    public float spawnInterval = 5f; // Interval waktu antara spawn musuh
    public int maxEnemies = 4; // Jumlah maksimal musuh dalam scene

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (enemies.Count < maxEnemies)
            {
                SpawnEnemyAtRandomLocation();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyAtRandomLocation()
    {
        // Pilih lokasi spawn secara acak
        Transform randomSpawnLocation = GetRandomSpawnLocation();

        // Spawn musuh pada lokasi yang dipilih
        GameObject enemy = Instantiate(spawnPrefab, randomSpawnLocation.position, randomSpawnLocation.rotation);

        // Tambahkan musuh ke daftar
        enemies.Add(enemy);

        // Tambahkan script FollowCamera dan setel referensi kamera
        FollowPlayer followCamera = enemy.GetComponent<FollowPlayer>();
        if (followCamera != null)
        {
            followCamera.player = Camera.main.transform;
        }

        // Setel callback untuk menghapus musuh dari daftar saat musuh dihancurkan dan spawn musuh baru setelah 3 detik
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.OnDestroyed += () =>
            {
                enemies.Remove(enemy);
                StartCoroutine(RespawnEnemyAfterDelay(3f));
            };
        }
    }

    Transform GetRandomSpawnLocation()
    {
        // Pilih indeks acak dari array spawnLocations
        int randomIndex = Random.Range(0, spawnLocations.Length);
        return spawnLocations[randomIndex];
    }

    private IEnumerator RespawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemies.Count < maxEnemies)
        {
            SpawnEnemyAtRandomLocation();
        }
    }
}
