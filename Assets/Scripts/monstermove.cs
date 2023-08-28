using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstermove : MonoBehaviour
{
    [Header("speed")]
    public float speed = 2f;
    [Header("target")]
    public GameObject target;


    void Start()
    {

    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }


}
