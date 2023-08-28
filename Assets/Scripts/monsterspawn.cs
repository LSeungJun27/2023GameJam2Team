using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawn : MonoBehaviour
{
    [Header("monster")]
    public GameObject spawnableObject;
    [Header("spawn interval")]
    public float spawnInterval = 3f;
    public float radius = 3f;


    private float timer = 0f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Target");
    }


    void Update()
    {
        Vector3 playerPosition = player.transform.position;

        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 randomPosition = new Vector3(Mathf.Cos(randomAngle), 2, Mathf.Sin(randomAngle)) * radius;
        randomPosition += playerPosition;



        if (timer <= 0f)
        {
            timer = spawnInterval;
            Instantiate(spawnableObject, randomPosition, Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
