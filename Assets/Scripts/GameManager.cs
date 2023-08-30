using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
        public static GameManager instance;
        private Camera _camera;
        public CinemachineBrain brain;
        public CinemachineVirtualCamera menuCam;
        public CinemachineVirtualCamera inGameCam;
        public UnityEvent onStart;
        public UnityEvent onEnemyDie;
        public bool gameStart = false;
        public hpcount playerHpcount;
        public hpcount cartHpcount;

    //점수
    public Text BestScroetxt;
    private int bestscore = 0;
    private string KeyName = "Best";
    [SerializeField] public Text Scoretxt;
    private float YouScore;
    private int RealScore;
    private int KillScore = 0;
    public int killbonus = 2;

        private void Awake()
        {
            instance = this;
            _camera = Camera.main;
            brain = _camera.GetComponent<CinemachineBrain>();
            cartHpcount.gameObject.SetActive(false);
            onStart.AddListener(() =>
            {
                gameStart = true;
                cartHpcount.gameObject.SetActive(true);
            });
            onEnemyDie.AddListener(() =>
            {
                Kill();
            });
        
        //점수
        bestscore = PlayerPrefs.GetInt(KeyName, 0);
        BestScroetxt.text = bestscore.ToString();


        }
      
    //점수
    public void Kill()
    {
        KillScore += killbonus;
        //Debug.Log("적 사망");
        //Debug.Log(KillScore);
    }

    //점수
    public void ScoreCount()
    {
        YouScore += Time.deltaTime;
        int Ks = GetComponent<GameManager>().KillScore;
        RealScore = Mathf.FloorToInt(YouScore) + KillScore;
        if (RealScore > bestscore)
        {
            PlayerPrefs.SetInt(KeyName, RealScore);
            bestscore = RealScore;
        }
        Scoretxt.text = "Score : " + RealScore.ToString();
        BestScroetxt.text = bestscore.ToString();
    }
        

        // Start is called before the first frame update
    void Start()
    {
        //점수
            YouScore = 0;
    }

        // Update is called once per frame
    void Update()
    {
        //점수
        ScoreCount();
    }
} 


