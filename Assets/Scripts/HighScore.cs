using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private int timer;

    // Update is called once per frame
    void Update()
    {
        timer += (int) Time.time;
        scoreText.text = timer.ToString();
       
    }
}
