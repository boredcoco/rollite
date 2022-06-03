using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
