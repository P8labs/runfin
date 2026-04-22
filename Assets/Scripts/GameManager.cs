using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool GAME_OVER;
    public GameObject gameOverPanel;

    void Start()
    {
        GAME_OVER = false;
        Time.timeScale = 1;

    }

    void Update()
    {

        if (GAME_OVER)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);


    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
