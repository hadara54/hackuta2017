using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightiningStikeScript : MonoBehaviour
{
    public float spawnWait;
    float lastSpawnTime;

    public GameObject prefab;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + spawnWait)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
