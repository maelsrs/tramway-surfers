using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private TextMeshProUGUI scoreText;
    private int score;

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
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
