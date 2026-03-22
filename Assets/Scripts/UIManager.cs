using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("PlayButton").GetComponent<Button>().onClick.AddListener(Play);
        GameObject.Find("QuitButton").GetComponent<Button>().onClick.AddListener(Quit);
    }

    void Play()
    {
        SceneManager.LoadScene("Game");
    }

    void Quit()
    {
        Application.Quit();
    }
}
