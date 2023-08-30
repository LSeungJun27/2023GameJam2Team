using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class monsterspawn : MonoBehaviour
{
    [Header("monster")]
    public GameObject spawnableObject;
    [Header("spawn interval")]
    public float spawnInterval = 3f;
    public float radius = 3f;



    public UnityEvent<GameObject> onEnemySpawn;


    private float timer = 0f;

    private GameObject player;

    public static monsterspawn instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Target");
        
    }


    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Target");
            return;
        }
        Vector3 playerPosition = player.transform.position;

        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 randomPosition = new Vector3(Mathf.Cos(randomAngle) * radius, 1, Mathf.Sin(randomAngle) * radius);
        randomPosition += playerPosition;



        if (timer <= 0f)
        {
            timer = spawnInterval;
            GameObject tmp=Instantiate(spawnableObject, randomPosition, Quaternion.identity);
            tmp.GetComponent<EnemyAi>().waypoints.Add(player.transform);
            onEnemySpawn.Invoke(tmp);
        }
        timer -= Time.deltaTime;


        


    }
    


}




