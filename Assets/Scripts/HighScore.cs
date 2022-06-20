using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private int timer = 0;

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
        startTimer();
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
    }
}
