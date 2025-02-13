using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager Instance { set; get; }
    public TMP_Text timerText;
    public TMP_Text messageText;
    public TMP_Text boxCountText;
    public GameObject endGamePanel;
    public GameObject endGameButton;
    private bool isGameOver;
    public static int boxCount;
    [SerializeField]private float timer = 120;
    void Awake()
    {
        boxCountText.enabled = true;
        timerText.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        endGamePanel.SetActive(false);
        if (Instance && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
           
            timer -= Time.deltaTime;
            boxCountText.text = "Box :  " + boxCount;
            timerText.text = "Time left : " + Mathf.Ceil(timer).ToString("F0");
            if (timer <= 0)
            {
                boxCountText.enabled = false;
                timerText.enabled = false;
                StopGame();
            }
        }

    }
    public static void StopGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (Instance != null && !Instance.isGameOver)
        {
            Instance.isGameOver = true;
            if (Instance.messageText != null)
            {
                Instance.messageText.text = "Wow your score is : " + boxCount;
            }
            if (Instance.endGamePanel != null)
            {
                Instance.endGamePanel.SetActive(true);
            }
        }
    }
    
}