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
        SceneManager.LoadScene(0);
        quitting = false;
    }

    public void noQuit()
    {
        quitPopUp.SetActive(false);
        quitting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitting)
            {
                quitting = false;
                quitPopUp.SetActive(false);
            } else
            {
                quitting = true;
                quitPopUp.SetActive(true);
            }
        }
    }

}
