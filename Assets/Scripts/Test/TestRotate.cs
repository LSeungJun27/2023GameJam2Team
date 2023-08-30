using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    public float rotateSpeed;
    public float rotateRadius;
    public Vector3 center;

    void Update()
    {
        float angle = Time.time * rotateSpeed * Mathf.Deg2Rad;
        Vector3 p = center + new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle))*rotateRadius;
        transform.position =p ;
    }
}
