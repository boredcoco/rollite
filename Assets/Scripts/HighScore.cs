using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static string lastScoreTxt = "000"; //new addition

    public static int timer = 0;

    void startTimer()
    {
        timer = 0;
        InvokeRepeating("incrementTime", 1, 1);
    }

    public void stopTimer()
    {
        CancelInvoke();
    }

    public void continueTimer()
    {
        InvokeRepeating("incrementTime", 1, 1);
    }

    void incrementTime()
    {
        timer += 1;
        scoreText.text = timer.ToString();
    }

    void Start()
    {
        //just added
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Retry"))
        {
          scoreText.text = lastScoreTxt;
        } else
        {
          startTimer(); //this was all that was here originally
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (Quit.quitting)
          {
            continueTimer();
          }
          else
          {
            stopTimer();
          }
        }
        //this clause is a new addition
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Retry"))
        {
          lastScoreTxt = scoreText.text;
        }
    }
}
