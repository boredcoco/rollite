using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    public static bool quitting = false;
    public GameObject quitPopUp;

    public void yesQuit()
    {
        SceneManager.LoadScene("Main Menu");
        quitting = false;
        Time.timeScale = 1;
    }

    public void noQuit()
    {
        quitPopUp.SetActive(false);
        quitting = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            askIfQuit();
        }
    }

    public void askIfQuit()
    {
        if (quitting)
        {
            quitting = false;
            quitPopUp.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            quitting = true;
            quitPopUp.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
