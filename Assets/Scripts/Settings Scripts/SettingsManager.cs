using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;


    public static int BGMNum = 1;

    [SerializeField] private Sprite bluePlane;
    [SerializeField] private Sprite pinkPlane;
    [SerializeField] private Sprite purplePlane;

    public Image plane;

    public AudioMixer audioMixer;

    private void Start()
    {
      bgmSlider.value = PlayerPrefs.GetFloat("BGMvol", 0.5f);
      sfxSlider.value = PlayerPrefs.GetFloat("SFXvol", 0.5f);
    }

    public void colourOne()
    {
        BGColour.background = Setup.firstColour;
        plane.sprite = bluePlane;
        PlaneColour.defaultColour = bluePlane;
        BGMNum = 1;
    }

    public void colourTwo()
    {
        BGColour.background = Setup.secondColour;
        plane.sprite = pinkPlane;
        PlaneColour.defaultColour = pinkPlane;
        BGMNum = 2;
    }

    public void colourThree()
    {
        BGColour.background = Setup.thirdColour;
        plane.sprite = purplePlane;
        PlaneColour.defaultColour = purplePlane;
        BGMNum = 3;
    }

    public void setSpeed(int speed)
    {

        if (speed == 1)
        {
            BasicMovement.speed = 6f;
            BasicMovement.dashForce = 10f;
        }
        else if (speed == 2)
        {
            BasicMovement.speed = 8f;
            BasicMovement.dashForce = 15f;
        }
        else
        {
            BasicMovement.speed = 12f;
            BasicMovement.dashForce = 20f;
        }
    }

    public void setVolume_bgm()
    {
        PlayerPrefs.SetFloat("BGMvol", bgmSlider.value);
        audioMixer.SetFloat("BGM", 30f * Mathf.Log10(PlayerPrefs.GetFloat("BGMvol")));
    }

    public void setVolume_sfx()
    {
      PlayerPrefs.SetFloat("SFXvol", sfxSlider.value);
      audioMixer.SetFloat("Sound Effects", 30f * Mathf.Log10(PlayerPrefs.GetFloat("SFXvol")));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
