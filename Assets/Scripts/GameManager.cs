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
            onStart.AddListener(() => { gameStart = true;});
            onEnemyDie.AddListener(() =>
            {
                Kill();
            });
        }
        
    public void Kill()
    {
        KillScore += killbonus;
        //Debug.Log("적 사망");
        //Debug.Log(KillScore);
    }

    public void ScoreCount()
    {
        //점수
        YouScore += Time.deltaTime;
        int Ks = GetComponent<GameManager>().KillScore;
        RealScore = Mathf.FloorToInt(YouScore) + KillScore;
        Scoretxt.text = "Score : " + RealScore.ToString();
    }
        

        // Start is called before the first frame update
    void Start()
    {
            YouScore = 0;
    }

        // Update is called once per frame
    void Update()
    {
        ScoreCount();
    }
} 


