using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSettings : MonoBehaviour
{
    public static int obsNum = 3;
    public static string obs_orientation = "random";

    [SerializeField] private Image horizontal;
    [SerializeField] private Image vertical;
    [SerializeField] private Image random;

    private void Start()
    {
      horizontal.enabled = false;
      vertical.enabled = false;
    }

    public void changeNumOfObstacles(int i)
    {
      obsNum = i;
    }

    public void changeOrientation(string ori)
    {
      obs_orientation = ori;

      if (ori == "horizontal")
      {
        vertical.enabled = false;
        random.enabled = false;
        horizontal.enabled = true;
      }
      if (ori == "vertical")
      {
        random.enabled = false;
        horizontal.enabled = false;
        vertical.enabled = true;
      }
      if (ori == "random")
      {
        horizontal.enabled = false;
        vertical.enabled = false;
        random.enabled = true;
      }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
