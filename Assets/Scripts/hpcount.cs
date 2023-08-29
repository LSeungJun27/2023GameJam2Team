using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//hp bar���Ŀ� �°� �Ϸ��� �ߴµ� �� �ȵƳ׿�.. �˼��մϴ�. ������ �ִ� �ڵ�� �Ʒ��ʿ� �ּ��������� �ֽ��ϴ�..

public class hpcount : MonoBehaviour
{
    //public Slider healthSlider;  // Slider UI ���
    public float maxHP = 100;       // �ִ� ü��
    public float currentHP;        // ���� ü��
    [SerializeField] private Text hptxt;
    public float MobDamage = 18f;

    void Start()
    {
        currentHP = maxHP;
        //healthSlider.maxValue = maxHP;
        //healthSlider.value = currentHP;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP < 0)
        {
            currentHP = 0;
        }

        //healthSlider.value = currentHP;

        if (currentHP <= 0)
        {
        }
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

//�Ʒ��� ������ �ߴ� hp UI

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class hpcount : MonoBehaviour
//{
//    [SerializeField] private Text hptxt;
//    [Header("Helth")]
//    public float hp;
//    [Header("MAX_HP")]
//    public float maxhp = 100f;
//    public float MobDamage;

//    [SerializeField] private Image barImage;

//    public GameObject[] lifes;
//    private List<GameObject> generatedgameObject = new List<GameObject>();

//    void Start()
//    {
//        hp = maxhp;
//    }


//    private void ChangeHealthBarAmount(float amount) //* HP ������ ���� 
//    {
//        barImage.fillAmount = amount;
//    }

//    void Update()
//    {

//        //if (hptxt != null)
//        //{
//        //    hptxt.text = hp.ToString();
//        //}
//        //for (int i = 0; i < lifes.Length; i++)
//        //{
//        //    this.lifes[i].SetActive(false);
//        //}
//        //for (int j = 0; j < hp; j++)
//        //{
//        //    this.lifes[j].SetActive(true);
//        //}

//    }
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("enemy"))
//        {
//            Destroy(other.gameObject);
//            hp = hp - MobDamage;
//        }

//        if (hp <= 0)
//        {
//            hptxt.text = hp.ToString();
//            for (int i = 0; i < lifes.Length; i++)
//            {
//                this.lifes[i].SetActive(false);
//            }

//            Destroy(gameObject);



//        }

//    }
//}