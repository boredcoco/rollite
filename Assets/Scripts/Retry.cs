using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("Base");
    }

    public void returnMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
