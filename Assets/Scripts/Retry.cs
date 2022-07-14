using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void singleplayerRestart()
    {
        SceneManager.LoadScene("SinglePlayer Base");
    }

    public void multiplayerRestart()
    {
        SceneManager.LoadScene("Base");
    }

    public void returnMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
