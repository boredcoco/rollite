using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
      GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
      if (obj.Length > 1)
      {
        Destroy(this.gameObject);
      } else
      {
        DontDestroyOnLoad(this.gameObject);
      }
    }

    private void Update()
    {
      if (SceneManager.GetActiveScene().name == "Base"
      || SceneManager.GetActiveScene().name == "SinglePlayer Base")
      {
        Destroy(this.gameObject);
      }
    }
}
