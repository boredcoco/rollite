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

    [SerializeField] private Sprite selected;
    [SerializeField] private Sprite unselected;

    [SerializeField] private Button num1;
    [SerializeField] private Button num2;
    [SerializeField] private Button num3;
    [SerializeField] private Button ori1;
    [SerializeField] private Button ori2;
    [SerializeField] private Button ori3;


    private void Start()
    {
        obsNum = PlayerPrefs.GetInt("obstacles", 3);
        changeNumOfObstacles(obsNum);

        obs_orientation = PlayerPrefs.GetString("orientation", "Random");
        changeOrientation(obs_orientation);

        if (PlayerPrefs.GetString("haveObstacles", "Yes") == "Yes")
        {
            have_obstacles = false;
        } else
        {
            have_obstacles = true;
        }
        toggleObstacles();
    }

    public void changeNumOfObstacles(int i)
    {
        obsNum = i;
        PlayerPrefs.SetInt("obstacles", i);
        numOfObs_desc.changeSomething(obsNum.ToString());

        num1.image.sprite = unselected;
        num2.image.sprite = unselected;
        num3.image.sprite = unselected;


        if (i == 1)
        {
            num1.image.sprite = selected;
        }
        else if (i == 3)
        {
            num2.image.sprite = selected;
        }
        else
        {
            num3.image.sprite = selected;
        }
    }

    public void changeOrientation(string ori)
    {
        obs_orientation = ori;
        PlayerPrefs.SetString("orientation", ori);

        ori1.image.sprite = unselected;
        ori2.image.sprite = unselected;
        ori3.image.sprite = unselected;

        if (ori == "Horizontal")
        {
            vertical.enabled = false;
            random.enabled = false;
            horizontal.enabled = true;

            ori1.image.sprite = selected;
        }
        if (ori == "Vertical")
        {
            random.enabled = false;
            horizontal.enabled = false;
            vertical.enabled = true;

            ori2.image.sprite = selected;
        }
        if (ori == "Random")
        {
            horizontal.enabled = false;
            vertical.enabled = false;
            random.enabled = true;

            ori3.image.sprite = selected;
        }

        orientation_desc.changeSomething(ori);
    }

    public void toggleObstacles()
    {
        have_obstacles = !have_obstacles;

        if (have_obstacles)
        {
            PlayerPrefs.SetString("haveObstacles", "Yes");
            haveObs_desc.changeSomething("Yes");
            noObstacle_image.sprite = unselected;
        }
        else
        {
            PlayerPrefs.SetString("haveObstacles", "No");
            haveObs_desc.changeSomething("No");
            noObstacle_image.sprite = selected;
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
