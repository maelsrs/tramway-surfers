using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float baseSpeed = 5f;
    public float speedIncreaseRate = 0.15f;
    public float maxSpeed = 15f;

    private GameObject gameOverPanel;
    private TextMeshProUGUI finalScoreText;
    private bool isGameOver;
    private float elapsedTime;

    public float CurrentSpeed => Mathf.Min(baseSpeed + elapsedTime * speedIncreaseRate, maxSpeed);
    public float SpeedMultiplier => CurrentSpeed / baseSpeed;
    public bool IsGameOver() => isGameOver;

void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();

        GameObject.Find("RestartButton").GetComponent<Button>().onClick.AddListener(Restart);
        GameObject.Find("MenuButton").GetComponent<Button>().onClick.AddListener(GoToMenu);

        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
            elapsedTime += Time.deltaTime;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
