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
        public bool gameStart = false;
        
        private void Awake()
        {
            instance = this;
            _camera = Camera.main;
            brain = _camera.GetComponent<CinemachineBrain>();
            onStart.AddListener(() => { gameStart = true;});
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


