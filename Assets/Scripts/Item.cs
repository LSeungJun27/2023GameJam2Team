using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{

    public GameObject ui;
    private Camera _camera;
    public int amount;

    private void Start()
    {
        _camera = Camera.main;
        
        ui.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact")&&ui.activeSelf)
        {
            ItemManager.instance.amount += amount;
            Destroy(transform.parent.gameObject);
            //Debug.Log("pickup");
        }
    }


    private void LateUpdate()
    {
        //ui.transform.LookAt(_camera);
        ui.transform.position = _camera.WorldToScreenPoint(gameObject.transform.position+Vector3.up);
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
