using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static string lastScoreTxt = "000"; //new addition

    public static int timer = 0;
    private int highscore = 0;

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

        // save highscore
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Base"))
        {
            if (highscore < timer)
            {
                PlayerPrefs.SetInt("MP Score", timer);
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer Base"))
        {
            if (highscore < timer)
            {
                PlayerPrefs.SetInt("SP Score", timer);
            }
        }

    }

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Retry"))
        {
          scoreText.text = lastScoreTxt;
        } else
        {
          startTimer(); 
        }


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Base"))
        {
            highscore = PlayerPrefs.GetInt("MP Score", 0);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer Base"))
        {
            highscore = PlayerPrefs.GetInt("SP Score", 0);
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
   
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Retry"))
        {
          lastScoreTxt = scoreText.text;
        }
    }
}
