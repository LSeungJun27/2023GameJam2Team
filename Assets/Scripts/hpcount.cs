using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class hpcount : MonoBehaviour
{
    //public Slider healthSlider;  // Slider UI ���
    public float maxHP = 100;       // �ִ� ü��
    public float currentHP;        // ���� ü��
    [SerializeField] private Text hptxt;
    public float MobDamage = 18f;
    public GameObject player;

    void Start()
    {
        currentHP = maxHP;
        player = GameObject.FindGameObjectWithTag("Player");
        //healthSlider.maxValue = maxHP;
        //healthSlider.value = currentHP;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            currentHP = currentHP - MobDamage;
        }

        if (currentHP <= 0)
        {
            hptxt.text = currentHP.ToString();

            Destroy(player.gameObject);
            Destroy(gameObject);
        }

    }
    void Update()
    {
        if (hptxt != null)
        {
            hptxt.text = currentHP.ToString();
        }
    }
}
