using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hpcount : MonoBehaviour
{
    [SerializeField] private Text hptxt;
    [Header("Helth")]
    public int hp=3;
    [Header("MAX_HP")]
    public int maxhp = 3;

    public GameObject[] lifes;
    private List<GameObject> generatedgameObject = new List<GameObject>();

    void Start()
    {
        hp = maxhp;
    }

    void Update()
    {

        if (hptxt != null)
        {
            hptxt.text = hp.ToString();
        }
        for (int i = 0; i < lifes.Length; i++)
        {
            this.lifes[i].SetActive(false);
        }
        for (int j = 0; j < hp; j++)
        {
            this.lifes[j].SetActive(true);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            hp = hp - 1;
        }

        if (hp <= 0)
        {
            hptxt.text = hp.ToString();
            for (int i = 0; i < lifes.Length; i++)
            {
                this.lifes[i].SetActive(false);
            }
            
            Destroy(gameObject);

            
            
        }

    }
}