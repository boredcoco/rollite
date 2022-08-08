using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class BackButton : MonoBehaviour
{
    [SerializeField] private AudioSource clicksound;

    public void backButton()
    {
        clicksound.Play();
        SceneManager.LoadScene("Main Menu");
    }
}
