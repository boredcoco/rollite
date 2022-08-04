using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setup : MonoBehaviour
{
    private int colour;
    private int speed;
    private float bgm;
    private float sfx;

    [SerializeField] public static Color firstColour = new Color(0.6992524f, 0.8516356f, 0.8679245f, 1);
    [SerializeField] public static Color secondColour = new Color(0.8784314f, 0.4980392f, 0.6039216f, 1);
    [SerializeField] public static Color thirdColour = new Color(0.1960784f, 0.1921569f, 0.4666667f, 1);

    [SerializeField] private Sprite bluePlane;
    [SerializeField] private Sprite pinkPlane;
    [SerializeField] private Sprite purplePlane;

    public AudioMixer audioMixer;

    private void Awake()
    {
        colour = PlayerPrefs.GetInt("colour", 1);
        speed = PlayerPrefs.GetInt("speed", 2);
        bgm = PlayerPrefs.GetFloat("BGMvol", 0.5f);
        sfx = PlayerPrefs.GetFloat("SFXvol", 0.5f);

    }

    // Start is called before the first frame update
    void Start()
    {
        // Setup Colour
        if (colour == 1)
        {
            PlaneColour.defaultColour = bluePlane;
            BGColour.background = firstColour;
        } else if (colour == 2)
        {
            PlaneColour.defaultColour = pinkPlane;
            BGColour.background = secondColour;
        } else
        {
            PlaneColour.defaultColour = purplePlane;
            BGColour.background = thirdColour;
        }

        // Setup Speed
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

        // Setup BG Music
        audioMixer.SetFloat("BGM", 30f * Mathf.Log10(bgm));

        // Setup SFX Music
        audioMixer.SetFloat("Sound Effects", 30f * Mathf.Log10(sfx));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
