using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void returnMain()
    {
        SceneManager.LoadScene(0);
    }
}
