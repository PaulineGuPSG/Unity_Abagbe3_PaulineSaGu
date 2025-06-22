using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    
    public int score = 0;
    public float timer = 0f;
    public bool gameStarted;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
        void Update()
        {
            if (gameStarted)
            {
                timer += Time.deltaTime;
            }
        }

        void StartGame()
        {
            gameStarted = true;
            startScreen.SetActive(false);
        }

        void WinGame()
        {
            gameStarted = false;
            winScreen.SetActive(true);
            UIManager.Instance.ShowFinalScore(score, timer);
        }

        void LoseGame()
        {
            gameStarted = false;
            loseScreen.SetActive(true);
        }

        void AddScore(int value)
        {
            score += value;
            UIManager.Instance.UpdateScore(score);
        }

        void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        }

    public void StartGame()
    {
        throw new System.NotImplementedException();
    }
}

