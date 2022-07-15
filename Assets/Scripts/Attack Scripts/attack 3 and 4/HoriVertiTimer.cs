using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoriVertiTimer : MonoBehaviour
{
    [SerializeField] private float activeTime = 5f;

    private float timer;

    private void Start()
    {
        timer = activeTime;
    }

    private void Update()
    {
        if (timer <= 0)
        {
          timer = activeTime;
          gameObject.SetActive(false);
        } else
        {
          timer -= Time.deltaTime;
        }
    }

}
