using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    private TMP_Text txt;
    private string defaultText;

    private void Start()
    {
        txt = GetComponent<TMP_Text>();
        defaultText = txt.text;
    }

    public void changeSomething(String str)
    {
      txt.text = defaultText + " " + str;
    }
}
