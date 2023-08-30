using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Vector3 v;

    // Update is called once per frame
    void Update()
    {
        transform.position += v * Time.deltaTime;
    }
}
