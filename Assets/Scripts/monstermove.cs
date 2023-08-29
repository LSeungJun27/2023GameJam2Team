using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstermove : MonoBehaviour
{
    [Header("speed")]
    public float speed = 10f;
    [Header("target")]
    public GameObject target;
    public float gravity = 500f;
    Vector3 direction;
    public float anispeed = 1f;

    Animator anim;
    CharacterController cc;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        MoveToTarget();

        float x = direction.x;
        float z = direction.z;


        if (direction != Vector3.zero)
        {
            // 진행 방향으로 캐릭터 회전
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg, 0);
            anim.SetFloat("Speed", anispeed);
        }
        if (direction == Vector3.zero)
        {
            anim.SetFloat("Speed", 0);
        }


        direction.y -= gravity * Time.deltaTime;
        cc.Move(direction * Time.deltaTime);
    }

    void MoveToTarget()
    {

        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }


    }

}
