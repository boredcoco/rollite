using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{

    public static Color firstColour = new Color(0.6992524f, 0.8516356f, 0.8679245f, 1);
    public static Color secondColour = new Color(0.8784314f, 0.4980392f, 0.6039216f, 1);
    public static Color thirdColour = new Color(0.1960784f, 0.1921569f, 0.4666667f, 1);

    public AudioMixer audioMixer;

    public static SettingsManager instance = null;


    public void colourOne()
    {
        BGColour.background = firstColour;
    }

    public void colourTwo()
    {
        BGColour.background = secondColour;
    }

    public void colourThree()
    {
        BGColour.background = thirdColour;
    }

    public void speedOne()
    {
        BasicMovement.speed = 4f;
    }

    public void speedTwo()
    {
        BasicMovement.speed = 7f;
    }

    public void speedThree()
    {
        BasicMovement.speed = 10f;
    }

    public void setVolume(float vol)
    {
        audioMixer.SetFloat("MasterVolume", vol);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
