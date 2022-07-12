using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void loadMapMenu()
    {
      SceneManager.LoadScene("Map Settings");
    }

    public void loadSinglePlayer()
    {
      SceneManager.LoadScene("SinglePlayer Base");
    }

}
