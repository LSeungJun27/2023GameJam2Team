using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    void Start()
    {
        GameOverUI.SetActive(false);
    }


    public static GameOver Instance { get; private set; } = null;




    private void Awake()
    {
        Instance = this;
    }


    public void SetGameOver()
    {
        GameManager.instance.gameStart = false;
        if (GameOverUI != null)
        {
            GameOverUI.SetActive(true);

        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Main");
    }

}
