using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class hpcount : MonoBehaviour
{
    //public Slider healthSlider;  // Slider UI 요소
    public float maxHP = 100;       // 최대 체력
    public float currentHP;        // 현재 체력
    [SerializeField] private Text hptxt;
    public float MobDamage = 18f;
    public GameObject player;
    public AudioSource enemyhit;

    void Start()
    {
        currentHP = maxHP;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyhit = GameObject.Find("Hit").GetComponent<AudioSource>();

        //healthSlider.maxValue = maxHP;
        //healthSlider.value = currentHP;
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (enemyhit.isPlaying)
        {
            enemyhit.Stop();
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            currentHP = currentHP - MobDamage;
            enemyhit.Play();
        }

        if (currentHP <= 0)
        {
            enemyhit.Play();
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
