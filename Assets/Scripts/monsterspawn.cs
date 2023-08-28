using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawn : MonoBehaviour
{
    [Header("monster")]
    public GameObject spawnableObject;
    [Header("spawn interval")]
    public float spawnInterval = 3f;
    public float radius = 7f;

    private float timer = 0f;
    void Update()
    {
        Vector3 playerPosition = transform.position;
        

        float a = playerPosition.x;
        float b = playerPosition.z;
        float rx = Random.Range(-radius + a, radius + a);
        float rz = Random.Range(-radius + b, radius + b);
        Vector3 randomPosition = new Vector3(rx, 1, rz);

        if (timer <= 0f)
        {
            timer = spawnInterval;
            Instantiate(spawnableObject, randomPosition, Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
