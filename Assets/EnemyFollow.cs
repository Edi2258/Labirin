using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject target in targets)
        {
            this.target = target.GetComponent<Transform>();
        }
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
