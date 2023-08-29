using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    Animator AtkAnim;
    public ParticleSystem fireEffect;
    private float atktime = 0.0f;
    public float maxatktime = 2.0f;
    public float cooltime = 1.0f;

    private int youcanatk = 1;

    private float noatk;

    void Start()
    {
        AtkAnim = GetComponent<Animator>();
        fireEffect.Stop();


    }

    void Update()
    {
        var amount = 10 * Time.deltaTime;
        if (youcanatk == 1)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                //noatk = cooltime;
                if (GameManager.instance.playerHpcount.currentHP > amount)
                {
                    GameManager.instance.playerHpcount.currentHP -= amount;
                    AtkAnim.SetTrigger("Attack");
                    fireEffect.Play();
                
                    Debug.Log("발사");
                }
                else
                {
                    fireEffect.Stop();
                }
                
            }else if (Input.GetMouseButton(0))
            {
                
                if (GameManager.instance.playerHpcount.currentHP > amount)
                {
                    GameManager.instance.playerHpcount.currentHP -= amount;
                }else
                {
                    fireEffect.Stop();
                }
                
            }
            /*
            if (Input.GetMouseButtonDown(0))
            {
                fireEffect.Play();
            }
            */


            /*
                if (Input.GetMouseButton(0))
            {
                
                atktime += Time.deltaTime * 4.0f;

                Debug.Log(atktime);
                Debug.Log("증가중");

                if (atktime >= maxatktime)
                {
                    fireEffect.Stop();
                    youcanatk = 0;
                    Debug.Log("과열");
                }
                
            }
            */

            else if (Input.GetMouseButtonUp(0))
            {
                fireEffect.Stop();
                
            }
            /*
            if (atktime >= 0)
            {
                atktime -= Time.deltaTime * 2.0f;
                Debug.Log(atktime);
                Debug.Log("감소중");
            }
            */
        }
        /*
        else if (youcanatk == 0)
        {
            if (noatk <= 0)
            {
                youcanatk = 1; // 다시 공격 가능 상태로 변경
                atktime = 0.0f;
            }
            noatk -= Time.deltaTime;
        }
        */
    }



}
