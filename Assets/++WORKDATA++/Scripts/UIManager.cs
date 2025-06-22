using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text scoreText;
    public Text timerText;
    public Text finalScoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            timerText.text = "Time: " + Math.Round(GameManager.Instance.timer, 1).ToString() + "s";
        }
    }

    public void UpdateScore(int score)
    {
        object finalscoreText;
        finalscoreText = "Final Score: " + score + "\nTime: " + Math.Round(time, 1) + "s";
    }

    public decimal time { get; set; }

    public void ShowFinalScore(int score, float timer)
    {
        throw new NotImplementedException();
    }
}