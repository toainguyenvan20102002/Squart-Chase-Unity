using UnityEngine.UI;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    public GameObject player;

    [Space]

    public GameObject panelEndgame;
    public Text textScoreInGame;
    public Text textHighScore;
    public Text textYourScore;
    public Text textNotifyNewHighScore;
    [Space]


    public GameObject leftDirect,rightDirect,topDirect,bottomDirect;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    private void Update()
    {
        DirectPoint();
    }

    public void UpdatePoint(int point)
    {
        textScoreInGame.text = point.ToString() + "/2002";
    }

    public void NotifyEndGame()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        textHighScore.text ="High Score: " + highScore.ToString() + "/2002";

        int yourPoint = PointManager.instance.GetPoint();
        textYourScore.text ="Your Score: "+ yourPoint.ToString() + "/2002";

        if (highScore < yourPoint)
        {
            textNotifyNewHighScore.gameObject.SetActive(true);
            highScore = yourPoint;
        }
        else textNotifyNewHighScore.gameObject.SetActive(false);

        PlayerPrefs.SetInt("HighScore", highScore);

        panelEndgame.SetActive(true);
    }

    public void DirectPoint()
    {
        Vector2 currentPointPosition = PointManager.instance.GetCurrentPointPosition();
        bool top = false;
        bool right = false;

        if (currentPointPosition.y > player.transform.position.y)
            top = true;
        else top = false;

        if (currentPointPosition.x > player.transform.position.x)
            right = true;
        else right = false;

        topDirect.SetActive(top);
        bottomDirect.SetActive(!top);
        rightDirect.SetActive(right);
        leftDirect.SetActive(!right);
    }
}
