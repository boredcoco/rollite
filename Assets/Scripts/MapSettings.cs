using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSettings : MonoBehaviour
{
    public static int obsNum = 3;
    public static bool have_obstacles = true;
    public static string obs_orientation = "random";

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
      if (have_obstacles) noObstacle_image.color = new Color32(45, 124, 66, 100);
      else noObstacle_image.color = Color.white;
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
        noObstacle_image.color = new Color32(45, 124, 66, 100);
        haveObs_desc.changeSomething("Yes");
      }
      else
      {
        noObstacle_image.color  = Color.white;
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
