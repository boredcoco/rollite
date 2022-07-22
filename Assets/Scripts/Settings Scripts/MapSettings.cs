using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSettings : MonoBehaviour
{
    public static int obsNum = 3;
    public static bool have_obstacles = true;
    public static string obs_orientation = "Random";

    [SerializeField] private Image horizontal;
    [SerializeField] private Image vertical;
    [SerializeField] private Image random;

    [SerializeField] private Image noObstacle_image;

    [SerializeField] private Description numOfObs_desc;
    [SerializeField] private Description orientation_desc;
    [SerializeField] private Description haveObs_desc;

    private void Start()
    {
      horizontal.enabled = false;
      vertical.enabled = false;
    }

    public void changeNumOfObstacles(int i)
    {
      obsNum = i;
      numOfObs_desc.changeSomething(i.ToString());
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
      orientation_desc.changeSomething(ori);
    }

    public void obstaclePresent()
    {
      have_obstacles = !have_obstacles;
      if (have_obstacles)
      {
        haveObs_desc.changeSomething("Yes");
      }
      else
      {
        haveObs_desc.changeSomething("No");
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
