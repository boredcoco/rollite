using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI singleplayerScore;
    public TextMeshProUGUI multiplayerScore;

    [SerializeField] private AudioSource clickSound;

    void Start()
    {
        singleplayerScore.text = PlayerPrefs.GetInt("SP Score", 0).ToString();
        multiplayerScore.text = PlayerPrefs.GetInt("MP Score", 0).ToString();
    }

    public void loadMultiplayer()
    {
        clickSound.Play();
        SceneManager.LoadScene("Base");
    }

    public void loadSingleplayer()
    {
        clickSound.Play();
        SceneManager.LoadScene("SinglePlayer Base");
    }

    public void settings()
    {
        clickSound.Play();
        SceneManager.LoadScene("Settings");
    }

    public void loadMapMenu()
    {
      clickSound.Play();
      SceneManager.LoadScene("Map Settings");
    }

    public void loadInstructions()
    {
        clickSound.Play();
        SceneManager.LoadScene("Instructions");
    }

    public void resetHighscores()
    {
        clickSound.Play();
        PlayerPrefs.SetInt("SP Score", 0);
        PlayerPrefs.SetInt("MP Score", 0);

        singleplayerScore.text = PlayerPrefs.GetInt("SP Score", 0).ToString();
        multiplayerScore.text = PlayerPrefs.GetInt("MP Score", 0).ToString();
    }

}
