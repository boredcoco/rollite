using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{

    private static Color firstColour = new Color(0.6992524f, 0.8516356f, 0.8679245f, 1);
    private static Color secondColour = new Color(0.5f, 0.5f, 0.5f, 1);
    private static Color thirdColour = new Color(0f, 0.5f, 0.5f, 1);

    public AudioMixer audioMixer;

    public static SettingsManager instance = null;

    /*
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    */

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
