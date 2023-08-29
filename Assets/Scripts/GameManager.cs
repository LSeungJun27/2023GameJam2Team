using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;


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
        
        private void Awake()
        {
            instance = this;
            _camera = Camera.main;
            brain = _camera.GetComponent<CinemachineBrain>();
            onStart.AddListener(() => { gameStart = true;});
            onEnemyDie.AddListener(() =>
            {
                Debug.Log("적 사망");
                //여기에 점수 관련 로직
            });
        }
        
        

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    } 


