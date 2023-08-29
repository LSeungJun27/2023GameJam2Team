using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public ParticleSystem ps;
    private int collisionCount = 0;
    private const int desiredCollisionCount = 3;

    private void Start()
    {
        monsterspawn.instance.onEnemySpawn.AddListener((obj) => { ps.trigger.AddCollider(obj.GetComponent<Collider>()); });
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("enemy"))
        {
            collisionCount++;

            if (collisionCount >= desiredCollisionCount)
            {
                Destroy(other.gameObject);
            }

            Debug.Log("enemy와 충돌했음");
        }
    }
}
