using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    private static float bgm_val = 0.5f;
    private static float sfx_val = 0.5f;

    public static int BGMNum = 1;
    public static Color firstColour = new Color(0.6992524f, 0.8516356f, 0.8679245f, 1);
    public static Color secondColour = new Color(0.8784314f, 0.4980392f, 0.6039216f, 1);
    public static Color thirdColour = new Color(0.1960784f, 0.1921569f, 0.4666667f, 1);

    public Sprite bluePlane;
    public Sprite pinkPlane;
    public Sprite purplePlane;

    public Image plane;

    public AudioMixer audioMixer;

    private void Start()
    {
      bgmSlider.value = bgm_val;
      sfxSlider.value = sfx_val;
    }

    public void colourOne()
    {
        BGColour.background = firstColour;
        plane.sprite = bluePlane;
        BGMNum = 1;
    }

    public void colourTwo()
    {
        BGColour.background = secondColour;
        plane.sprite = pinkPlane;
        BGMNum = 2;
    }

    public void colourThree()
    {
        BGColour.background = thirdColour;
        plane.sprite = purplePlane;
        BGMNum = 3;
    }

    public void speedOne()
    {
        BasicMovement.speed = 6f;
        BasicMovement.dashForce = 10f;
    }

    public void speedTwo()
    {
        BasicMovement.speed = 8f;
        BasicMovement.dashForce = 15f;
    }

    public void speedThree()
    {
        BasicMovement.speed = 12f;
        BasicMovement.dashForce = 20f;
    }

    public void setVolume_bgm(float vol)
    {
        bgm_val = bgmSlider.value;
        audioMixer.SetFloat("BGM", 30f * Mathf.Log10(bgm_val));
    }

    public void setVolume_sfx(float vol)
    {
      sfx_val = sfxSlider.value;
      audioMixer.SetFloat("Sound Effects", 30f * Mathf.Log10(sfx_val));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
