using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [Header("¼Óµµ")]
    public float speed = 5f;

    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += mainCameraTransform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= mainCameraTransform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= mainCameraTransform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += mainCameraTransform.right;
        }

        moveDirection.y = 0f;
        moveDirection.Normalize();


        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}
