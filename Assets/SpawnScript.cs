using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject theEnemy; // Prefab musuh yang akan di-spawn
    public int xPos;
    public int zPos;
    public int maxEnemies = 8; // Jumlah maksimal musuh dalam scene

    void Start()
    {
        // Mulai coroutine untuk spawn musuh
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            // Tunggu sampai jumlah musuh kurang dari jumlah maksimal
            while (CountEnemies() >= maxEnemies)
            {
                yield return new WaitForSeconds(1f);
            }

            // Spawn musuh baru
            xPos = Random.Range(1, 13);
            zPos = Random.Range(1, 13);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);

            // Tunggu beberapa detik sebelum mencoba spawn musuh lagi
            yield return new WaitForSeconds(3f);
        }
    }

    int CountEnemies()
    {
        // Menghitung jumlah musuh yang ada di dalam scene
        return GameObject.FindGameObjectsWithTag("Cube").Length;
    }
}
