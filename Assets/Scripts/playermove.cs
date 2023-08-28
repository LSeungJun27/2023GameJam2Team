using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Vector3 direction;
    public float speed = 2f;
    public float gravity = 500f;
    public float anispeed = 1f;

    Animator anim;
    CharacterController cc;

    public AudioClip footstep;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
            float x = Input.GetAxis("Horizontal")*(-1);
            float z = Input.GetAxis("Vertical") * (-1);

        direction = new Vector3(x, 0, z) * speed;

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
        cc.Move(direction* Time.deltaTime);
    }

}