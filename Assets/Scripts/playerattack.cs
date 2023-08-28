using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    Animator AtkAnim;

    void Start()
    {
        AtkAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AtkAnim.SetTrigger("Attack");
        }
    }

    
}
