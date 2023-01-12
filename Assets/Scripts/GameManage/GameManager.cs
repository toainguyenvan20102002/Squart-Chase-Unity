using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        GUIManager.instance.NotifyEndGame();
        AudioManager.instance.Stop("BackGroundMusic");
        AudioManager.instance.Play("EndGame");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        AudioManager.instance.Play("BackGroundMusic");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
