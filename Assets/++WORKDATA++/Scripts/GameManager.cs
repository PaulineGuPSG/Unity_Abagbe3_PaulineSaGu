using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Text pointsText;
    public Text timerText;
    public GameObject countdownUI;
    public Text countdownText;

    private int points = 0;
    private float timer = 0f;
    private bool gameActive = false;

    void Awake()
    {
        if (instance == null)  instance = this; 
        else Destroy(gameObject);
        
    }

    void Start()
    {
        StartCoroutine(StartCountdown());
        
    }

    IEnumerator StartCountdown()
    {
        countdownUI.SetActive(true);
        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownUI.SetActive(false);
        gameActive = true;
    }

    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (pointsText) pointsText.text = "Points: " + points;
        if (timerText) timerText.text = "Timer: " + timer.ToString("F1");
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("FinalScore", points);
        PlayerPrefs.SetFloat("TimeTaken", timer);
        SceneManager.LoadScene("Win Screen");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}