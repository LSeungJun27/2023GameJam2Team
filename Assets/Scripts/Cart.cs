using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public GameObject ui;
    private Camera _camera;
    public hpcount hpcount;

    private void Start()
    {
        _camera = Camera.main;
        
        ui.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetButton("Interact")&&ui.activeSelf)
        {
            var playerHpcount = GameManager.instance.playerHpcount;
            if (playerHpcount.currentHP > 20 * Time.deltaTime)
            {
                hpcount.currentHP += 20*Time.deltaTime;
                playerHpcount.currentHP-= 20*Time.deltaTime;
            }
            else
            {
                hpcount.currentHP += playerHpcount.currentHP;
                playerHpcount.currentHP= 0;
            }
            if (hpcount.currentHP > hpcount.maxHP)
            {
                playerHpcount.currentHP += hpcount.currentHP - hpcount.maxHP;
                hpcount.currentHP = hpcount.maxHP;
            }

            //Destroy(transform.parent.gameObject);
            //Debug.Log("pickup");
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
