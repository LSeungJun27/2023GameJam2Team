using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    Animator AtkAnim;
    public ParticleSystem fireEffect;
    

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

        if (Input.GetMouseButtonDown(0))
        {
            fireEffect.Play();
        }
        if(Input.GetMouseButtonUp(0))
        {
            fireEffect.Stop();
        }
    }

    
}
