using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    private bool quitting = false;
    public GameObject quit;

    public void yesQuit()
    {
        SceneManager.LoadScene(0);
    }

    public void noQuit()
    {
        quit.SetActive(false);
        quitting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitting)
            {
                quitting = false;
                quit.SetActive(false);
            } else
            {
                quitting = true;
                quit.SetActive(true);
            }
        }
    }

}
