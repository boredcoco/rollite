using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    [SerializeField] private int about;
    private TMP_Text txt;
    private string defaultText;

    private void Start()
    {
        txt = GetComponent<TMP_Text>();
        defaultText = txt.text;

        if (about == 1) txt.text = defaultText + " " + PlayerPrefs.GetInt("obstacles", 3).ToString();
        if (about == 2) txt.text = defaultText + " " + PlayerPrefs.GetString("orientation", "Random");

        if (about == 3)
        {
          txt.text = defaultText + " " + PlayerPrefs.GetString("haveObstacles", "Yes");
        }
    }

    public void changeSomething(String str)
    {
      txt.text = defaultText + " " + str;
    }
}
