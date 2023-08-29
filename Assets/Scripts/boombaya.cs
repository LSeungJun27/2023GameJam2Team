using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 엄청 많은 코드가 거쳐갔지만, 원래 있던 거 쓰셔도 될듯 합니다.

public class boombaya : MonoBehaviour
{
    public ParticleSystem waterDamage; // 이펙트 프리팹을 Inspector에서 할당
    public GameObject Damage;  

    void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("asdfasdfasdf");
        //showEffect(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnDestroy()
    {
        GameManager.instance.onEnemyDie.Invoke();
        GameObject fountain = Instantiate(Damage,transform);
        fountain.transform.parent = null;
    }


    void showEffect(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject fountain = Instantiate(Damage, contact.point, rot);
        fountain.transform.SetParent(this.transform);
    }
/*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }




    }*/
    //void OnParticleTrigger()

    //{
    //Debug.Log("충돌함");
    //}




}