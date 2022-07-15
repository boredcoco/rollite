using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_sound : MonoBehaviour
{
    [SerializeField] private GameObject BGM1;
    [SerializeField] private GameObject BGM2;
    [SerializeField] private GameObject BGM3;

    private void Start()
    {
        if (SettingsManager.BGMNum == 1) BGM1.SetActive(true);
        if (SettingsManager.BGMNum == 2) BGM2.SetActive(true);
        if (SettingsManager.BGMNum == 3) BGM3.SetActive(true);
    }
}
