using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TMP_Text livesText;
    public TMP_Text pointsText;

    [Header("Game Over UI")]
    public GameObject gameOverPanel; 

    [Header("Player Stats")]
    public int lives = 3;//initial lives
    public int points = 0;//initial points

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);//hides game over panel at start
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver(); 
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true);//shows game over panel
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;

        if (pointsText != null)
            pointsText.text = "Points: " + points;
    }

   
    public void RestartGame()
    {
        Time.timeScale = 1f; //starts game again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
