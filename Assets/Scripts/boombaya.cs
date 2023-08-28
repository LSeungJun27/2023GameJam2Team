using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 기존의 collider 스크립트dlqslek.

public class boombaya : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        

    }
}
