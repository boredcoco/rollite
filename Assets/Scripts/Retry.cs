using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] private AudioSource clicksound;

    public void singleplayerRestart()
    {
        clicksound.Play();
        SceneManager.LoadScene("SinglePlayer Base");
    }

    public void multiplayerRestart()
    {
        clicksound.Play();
        SceneManager.LoadScene("Base");
    }

    public void returnMain()
    {
        clicksound.Play();
        SceneManager.LoadScene("Main Menu");
    }
}
