using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
  public void quit()
  {
    Debug.Log("button pressed");
    SceneManager.LoadScene(0);
 }
}
