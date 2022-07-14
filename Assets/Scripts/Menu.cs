using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI singleplayerScore;
    public TextMeshProUGUI multiplayerScore;

    void Start()
    {
        singleplayerScore.text = PlayerPrefs.GetInt("SP Score", 0).ToString();
        multiplayerScore.text = PlayerPrefs.GetInt("MP Score", 0).ToString();
    }

    public void loadMultiplayer()
    {
        SceneManager.LoadScene("Base");
    }

    public void loadSingleplayer()
    {
        SceneManager.LoadScene("SinglePlayer Base");
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void loadMapMenu()
    {
      SceneManager.LoadScene("Map Settings");
    }

    public void loadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void resetHighscores()
    {
        PlayerPrefs.SetInt("SP Score", 0);
        PlayerPrefs.SetInt("MP Score", 0);

        singleplayerScore.text = PlayerPrefs.GetInt("SP Score", 0).ToString();
        multiplayerScore.text = PlayerPrefs.GetInt("MP Score", 0).ToString();
    }

}
