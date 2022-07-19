using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    [SerializeField] private AudioSource mainMenu_bgm;
    [SerializeField] private AudioSource littleEngine;
    [SerializeField] private AudioSource glitchBot;
    [SerializeField] private AudioSource spaceVoyager;
    [SerializeField] private AudioSource coldPlanet;

    private AudioSource current;

    private void Awake()
    {
      GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
      if (objs.Length > 1)
      {
        Destroy(this.gameObject);
      } else
      {
        DontDestroyOnLoad(this.gameObject);
      }
    }

    private void Update()
    {
      if (SceneManager.GetActiveScene().name == "Base"
      || SceneManager.GetActiveScene().name == "SinglePlayer Base")
      {
        if (!(current == littleEngine || current == glitchBot || current == spaceVoyager))
        {
          current.Stop();
          if (SettingsManager.BGMNum == 1) current = littleEngine;
          else if (SettingsManager.BGMNum == 2) current = glitchBot;
          else if (SettingsManager.BGMNum == 3) current = spaceVoyager;

          current.Play();
        }
      } else if (SceneManager.GetActiveScene().name == "Main Menu")
      {
        if (current == null)
        {
          current = mainMenu_bgm;
          current.Play();
        } else if (current != mainMenu_bgm)
        {
          current.Stop();
          current = mainMenu_bgm;
          current.Play();
        }
      } else if (SceneManager.GetActiveScene().name == "SP Retry"
      || SceneManager.GetActiveScene().name == "MP Retry")
      {
        if (current != coldPlanet)
        {
          current.Stop();
          current = coldPlanet;
          current.Play();
        }
      }

    }
}
