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
        if (about == 1) txt.text = defaultText + " " + MapSettings.obsNum.ToString();
        if (about == 2) txt.text = defaultText + " " + MapSettings.obs_orientation;
        if (about == 3)
        {
          if (MapSettings.have_obstacles) txt.text = defaultText + " Yes";
          else txt.text = defaultText + " No";
        }
    }

    public void changeSomething(String str)
    {
      txt.text = defaultText + " " + str;
    }
}
