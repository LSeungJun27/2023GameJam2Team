using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{

    public GameObject ui;
    private Camera _camera;
    public float amount;
    public AudioSource GetItem;

    private void Start()
    {
        _camera = Camera.main;
        
        ui.SetActive(false);
        GetItem = GameObject.Find("GetItem").GetComponent<AudioSource>();
        GetItem.Stop();
    }

    private void Update()
    {
        if (GetItem.isPlaying)
        {
            GetItem.Stop();
        }
        if (Input.GetButtonDown("Interact")&&ui.activeSelf)
        {
            //ItemManager.instance.amount += amount;
            GameManager.instance.playerHpcount.currentHP += amount;
            if (GameManager.instance.playerHpcount.currentHP > GameManager.instance.playerHpcount.maxHP)
                GameManager.instance.playerHpcount.currentHP=GameManager.instance.playerHpcount.maxHP;
            Destroy(transform.parent.gameObject);
            
            GetItem.Play();
            Debug.Log("pickup");
        }
    }


    private void LateUpdate()
    {
        //ui.transform.LookAt(_camera);
        ui.transform.position = _camera.WorldToScreenPoint(gameObject.transform.position+Vector3.up*0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("player enter");
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("player exit");
            ui.SetActive(false);
        }
    }
}
