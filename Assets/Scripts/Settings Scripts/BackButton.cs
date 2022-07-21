using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
